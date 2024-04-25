using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Principal;
using SzachTurniej.Data;
using SzachTurniej.Data.Enums;
using SzachTurniej.Migrations;

namespace SzachTurniej.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public TournamentService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _userManager = userManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        #region Pobiera aktualnie zalogowanego użytkownika
        public async Task<ApplicationUser> GetUserAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var currentUser = authState.User;

            if (currentUser.Identity.IsAuthenticated)
            {
                return await _userManager.GetUserAsync(currentUser);
            }

            return null;
        }
        #endregion

        #region Pobieranie listy turnieji

        #region Wszystkie turnieje
        public async Task<List<Tournament>> GetAll()
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return tournaments;
        }
        #endregion

        #region Wszystkie turnieje
        public async Task<List<Tournament>> GetLastFinished()
        {
            var tournaments = await _context.Tournaments.Where(x => x.Status == (int)TournamentStatusEnum.Finished).OrderByDescending(x => x.EndDate).Take(10).ToListAsync();
            return tournaments;
        }
        #endregion

        #region Wszystkie turnieje
        public async Task<List<Tournament>> GetLastOnPlanning()
        {
            var tournaments = await _context.Tournaments.Where(x => x.Status == (int)TournamentStatusEnum.Planning).OrderByDescending(x => x.StartDate).Take(10).ToListAsync();
            return tournaments;
        }
        #endregion

        #endregion

        #region Pobieranie turnieji użytkownika
        public async Task<List<Tournament>> UserTournaments()
        {
            var tournaments = new List<Tournament>();
            var user = await GetUserAsync();
            if (user != null)
            {
                tournaments = await _context.Tournaments.Where(x => x.RegisteredUsers.Contains(user)).ToListAsync();
            }
            return tournaments;
        }
        #endregion

        #region Tworzenie turnieju
        public async Task<Tournament> Create(Tournament tournament)
        {
            var user = await GetUserAsync();
            if (user != null)
            {
                tournament.CreatedBy = user.Id;
                tournament.Status = (int)TournamentStatusEnum.ToAccept;
                _context.Tournaments.Add(tournament);
                await _context.SaveChangesAsync();
            }

            
            return tournament;
        }
        #endregion

        #region Pobieranie turnieju (szczegóły)
        public async Task<Tournament?> GetById(int id)
        {
            var tournament = _context.Tournaments
                .Include(x => x.TournamentRounds)
                    .ThenInclude(s => s.Matches)
                        .ThenInclude(x => x.Player1)
                .Include(x => x.TournamentRounds)
                    .ThenInclude(s => s.Matches)
                        .ThenInclude(x => x.Player2)
                .FirstOrDefault(x => x.Id == id);
            if (tournament == null)
            {
                return null;
            }
            return tournament;
        }
        #endregion

        #region Aktualizacja turnieju
        public async Task Update(Tournament tournament)
        {
            _context.Entry(tournament).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Usuwanie turnieju
        public async Task<bool> Delete(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return false;
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Zapis gracza na turniej
        public async Task RegisterUserForTournament(string userId, int tournamentId)
        {
            var tournament = await GetById(tournamentId);
            var user = await _userManager.FindByIdAsync(userId);

            if (tournament != null && user != null && tournament.Status == (int)TournamentStatusEnum.Planning)
            {
                if (!tournament.RegisteredUsers.Any(u => u.Id == userId))
                {
                    tournament.RegisteredUsers.Add(user);
                    await Update(tournament);
                }
            }
        }
        #endregion

        #region Tworznie rund
        public void GenerateRound(int tournamentId)
        {
            var tournament = _context.Tournaments
                .Include(t => t.RegisteredUsers)
                .SingleOrDefault(t => t.Id == tournamentId);

            if (tournament == null)
            {
                throw new ArgumentException("Nie znaleziono turnieju.");
            }

            if (tournament.TournamentRounds.Count < 1)
            {
                // Dla testów
                var users = _userManager.Users.ToList();
                tournament.RegisteredUsers = users;

                // Generate first round
                var round = new TournamentRound { RoundNumber = 1, TournamentId = tournament.Id, Status = (int)RoundStatusEnum.OnGoing };
                var shuffledUsers = tournament.RegisteredUsers.OrderBy(u => Guid.NewGuid()).ToList(); // Shuffle users randomly

                if (shuffledUsers.Count % 2 != 0)
                {
                    // Add a bye for the player without an opponent
                    var byePlayer = shuffledUsers.Last(); // The last player in the shuffled list
                    shuffledUsers.RemoveAt(shuffledUsers.Count - 1); // Remove the last player from the list
                    var byeMatch = new Match
                    {
                        Player1 = byePlayer,
                        Player2 = null, // No opponent for the bye player
                        TournamentRoundId = round.Id,
                        Player1Score = 1, // Automatically give the bye player a score of 1 (a win)
                        Player2Score = 0, // By definition, the bye player has no opponent, so score is 0
                    };
                    round.Matches.Add(byeMatch);
                }

                for (int i = 0; i < shuffledUsers.Count - 1; i += 2)
                {
                    var match = new Match
                    {
                        Player1 = shuffledUsers[i],
                        Player2 = shuffledUsers[i + 1],
                        TournamentRoundId = round.Id
                    };
                    round.Matches.Add(match);
                }

                _context.TournamentRounds.Add(round);
                tournament.Status = (int)TournamentStatusEnum.OnGoing;
                _context.SaveChanges();
            }
            else
            {
                // Calculate standings
                var standings = GetStandings(tournamentId);

                // Create next round based on current standings
                var nextRoundNumber = tournament.TournamentRounds.Count + 1;
                var nextRound = GenerateRoundBasedOnStandings(tournament, standings, nextRoundNumber);
                _context.TournamentRounds.Add(nextRound);

                _context.SaveChanges();
            }
        }

        private TournamentRound GenerateRoundBasedOnStandings(Tournament tournament, List<TournamentStandings> standings, int roundNumber)
        {
            var round = new TournamentRound { RoundNumber = roundNumber, TournamentId = tournament.Id, Status = (int)RoundStatusEnum.OnGoing };

            // Pair players based on standings (Swiss system or any other algorithm)
            // Example: Pair players with similar points
            for (int i = 0; i < standings.Count - 1; i += 2)
            {
                var match = new Match
                {
                    Player1 = standings[i].User,
                    Player2 = standings[i + 1].User,
                    TournamentRoundId = round.Id
                };
                round.Matches.Add(match);
            }

            // If there's an odd number of players in the standings
            if (standings.Count % 2 != 0)
            {
                // Find the player with the lowest points (assuming standings are sorted)
                var byePlayer = standings.Last().User;

                // Create a bye match for the bye player
                var byeMatch = new Match
                {
                    Player1 = byePlayer,
                    Player2 = null, // No opponent for the bye player
                    TournamentRoundId = round.Id,
                    Player1Score = 1, // Automatically give the bye player a score of 1 (a win)
                    Player2Score = 0, // By definition, the bye player has no opponent, so score is 0
                };
                round.Matches.Add(byeMatch);
            }

            return round;
        }
        #endregion

        #region Zapis wyniku meczu
        public void RecordMatchScore(int matchId, double player1Score, double player2Score)
        {
            var match = _context.Matches.Find(matchId);
            if (match == null)
            {
                throw new ArgumentException("Nie znaleziono meczu.");
            }

            match.Player1Score = player1Score;
            match.Player2Score = player2Score;

            _context.SaveChanges();
        }
        #endregion

        #region Wyniki

        #region Pobieranie wyników
        public List<TournamentStandings> GetStandings(int tournamentId)
        {
            var standings = _context.TournamentStandings
                .Where(s => s.TournamentId == tournamentId)
                .Include(s => s.User)
                .OrderByDescending(s => s.Points)
                .ThenByDescending(s => s.BuchholzScore)
                .ToList();

            return standings;
        }
        #endregion

        #region Wyliczanie wyników (po rundzie)
        public void CalculateAndStoreStandings(int tournamentId, int roundId)
        {
            var tournament = _context.Tournaments
                .Include(t => t.RegisteredUsers)
                .Include(t => t.TournamentRounds)
                    .ThenInclude(r => r.Matches)
                .SingleOrDefault(t => t.Id == tournamentId);

            if (tournament == null)
            {
                throw new ArgumentException("Nie udało się odnaleźć turnieju o podanym Id.");
            }

            var tournamentRound = tournament.TournamentRounds.FirstOrDefault(x => x.Id == roundId);
            if (tournamentRound != null)
            {
                if (tournamentRound.Matches.Any(m => m.Player1Score == null || m.Player2Score == null))
                {
                    throw new InvalidOperationException("Runda jeszcze się nie zakończyła. Wypełnij wszystkie wyniki meczów.");
                }
                tournamentRound.Status = (int)RoundStatusEnum.Ended;
            }
            else
            {
                throw new ArgumentException("Nie udało się odnaleźć rundy o podanym Id.");
            }

            if (tournamentRound.RoundNumber > 1)
            {
                var standings = _context.TournamentStandings.Where(x => x.TournamentId == tournament.Id);
                foreach (var userStanding in standings)
                {
                    var points = CalculatePointsForUser(userStanding.User, tournamentRound);
                    userStanding.Points += points;
                }
            }
            else
            {
                foreach (var user in tournament.RegisteredUsers)
                {
                    var points = CalculatePointsForUser(user, tournamentRound);
                    // Store standings in the database
                    var userStandings = new TournamentStandings
                    {
                        TournamentId = tournamentId,
                        UserId = user.Id,
                        Points = points
                    };

                    _context.TournamentStandings.Add(userStandings);
                }
            }
            _context.SaveChanges();

            CalculateBuchholzPoints(tournamentId);

            if (tournament.Rounds == tournamentRound.RoundNumber)
            {
                tournament.Status = (int)TournamentStatusEnum.Finished;
                _context.SaveChanges();
            }
            else
            {
                GenerateRound(tournamentId);
            }
        }

        private double CalculatePointsForUser(ApplicationUser user, TournamentRound round)
        {
            double points = 0;

            var match = round.Matches.FirstOrDefault(x => x.Player1 == user || x.Player2 == user);
            if(match != null)
            {
                if (match.Player1 == user)
                {
                    points += (double)match.Player1Score;
                }
                else
                {
                    points += (double)match.Player2Score;
                }
            }

            return points;
        }

        private void CalculateBuchholzPoints(int tournamentId)
        {
            var tournament = _context.Tournaments
                .Include(x => x.TournamentRounds)
                    .ThenInclude(s => s.Matches)
                        .ThenInclude(x => x.Player1)
                .Include(x => x.TournamentRounds)
                    .ThenInclude(s => s.Matches)
                        .ThenInclude(x => x.Player2)
                .FirstOrDefault(x => x.Id == tournamentId);

            foreach (var user in tournament.RegisteredUsers)
            {
                //Definiujemy potrzebne zmienne
                double buchholzPoints = 0;
                var opponents = new List<ApplicationUser>();

                // Przechodzimy przez wszystkie rundy turnieju
                foreach (var round in tournament.TournamentRounds)
                {
                    // W danej rundzie bierzemy mecz w którym uczestniczył zawodnik (ApplicationUser user)
                    var match = round.Matches.FirstOrDefault(x => x.Player1 == user || x.Player2 == user);

                    // Jeżeli Player1 to nie jest nasz wyliczany gracz, oraz jeżeli ten zawodnik nie znajduje się już w liście przeciwników
                    // (nie chcemy aby w liście przeciwników znalazł się dwa razy ten sam przeciwnik)
                    // To wtedy dodanejmy tego przeciwnika do listy przeciwników
                    if (match.Player1 != user && !opponents.Contains(match.Player1))
                    {
                        var opponent = match.Player1;
                        opponents.Add(opponent);
                    }
                    // To co wyżej tylko sprawdzamy czy dla Player2 meczu
                    else if (match.Player2 != user && !opponents.Contains(match.Player2))
                    {
                        var opponent = match.Player2;
                        opponents.Add(opponent);
                    }
                }

                // Pobieramy wyniki w których znajdują się nasi przeciwnicy
                var standings = _context.TournamentStandings.AsNoTracking().Where(x => x.TournamentId == tournamentId && opponents.Contains(x.User));

                // Przechodzimy przez wszystkie wyniki i zliczamy punkty naszych przeciwników
                foreach (var standing in standings)
                {
                    buchholzPoints += standing.Points;
                }

                var userStanding = _context.TournamentStandings.FirstOrDefault(x => x.User == user && x.TournamentId == tournamentId);
                userStanding.BuchholzScore = buchholzPoints;
                _context.SaveChanges();
            }
        }
        #endregion

        #endregion
    }
}
