using Microsoft.EntityFrameworkCore;
using SzachTurniej.Data;

namespace SzachTurniej.Services
{
    public interface ITournamentService
    {
        Task<List<Tournament>> GetAll();
        Task<List<Tournament>> GetLastFinished();
        Task<List<Tournament>> GetLastOnPlanning();
        Task<List<Tournament>> UserTournaments();
        Task<Tournament> Create(Tournament tournament);
        Task<Tournament> GetById(int id);
        Task Update(Tournament tournament);
        Task<bool> Delete(int id);
        Task RegisterUserForTournament(string userId, int tournamentId);
        void GenerateRound(int tournamentId);
        void RecordMatchScore(int matchId, double player1Score, double player2Score);
        List<TournamentStandings> GetStandings(int tournamentId);
        void CalculateAndStoreStandings(int tournamentId, int roundId);
    }
}
