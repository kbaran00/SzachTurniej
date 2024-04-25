namespace SzachTurniej.Data
{
    public class Match
    {
        public int Id { get; set; }
        public ApplicationUser? Player1 { get; set; }
        public ApplicationUser? Player2 { get; set; }
        public double? Player1Score { get; set; } // Score for Player 1
        public double? Player2Score { get; set; } // Score for Player 2
        public int TournamentRoundId { get; set; }
        public TournamentRound TournamentRound { get; set; }
    }
}
