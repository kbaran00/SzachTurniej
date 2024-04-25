namespace SzachTurniej.Data
{
    public class TournamentRound
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public List<Match> Matches { get; set; } = new List<Match>(); // Changed Pairings to Matches
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int Status { get; set; }
    }
}
