namespace SzachTurniej.Data
{
    public class TournamentStandings
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public double Points { get; set; }
        public double BuchholzScore { get; set; }
    }
}
