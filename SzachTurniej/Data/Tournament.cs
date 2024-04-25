using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SzachTurniej.Data
{
    public class Tournament
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa turnieju jest wymagana")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Data zakończenia jest wymagana")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Wymanage jest podanie lokalizacji turnieju")]
        public string Location { get; set; }
        public int Type { get; set; }
        [Required(ErrorMessage = "Wymanage jest czasu podstawowego")]
        [Range(1, int.MaxValue, ErrorMessage = "Czas podstawowy musi być większy niż 0.")]
        public int BasicTime { get; set; }
        public int BasicTimeType { get; set; }
        public int AdditionalTime { get; set; }
        public int AdditionalTimeType { get; set; }
        [Required(ErrorMessage = "Liczba rund jest wymagana")]
        [Range(1, int.MaxValue, ErrorMessage = "Liczba rund musi być większa niż 0.")]
        public int Rounds { get; set; }
        public int Status { get; set; }
        [Required(ErrorMessage = "Sędzia jest wymagany")]
        public string Arbiter { get; set; }
        public string CreatedBy { get; set; }
        public string? Regulation { get; set; }
        public List<TournamentRound> TournamentRounds { get; set; } = new List<TournamentRound>();
        public List<ApplicationUser> RegisteredUsers { get; set; } = new List<ApplicationUser>(); // Added navigation property
    }
}
