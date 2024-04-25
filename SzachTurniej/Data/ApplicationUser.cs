using Microsoft.AspNetCore.Identity;

namespace SzachTurniej.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly? BirthDate { get; set; }
        public int? Sex { get; set; }
        public string? City { get; set; }
        public int? ChessCategory { get; set; }
        public string? Club { get; set; }
        public int? RankingPZSZACH { get; set; }
        public int? RankingFIDE { get; set; }
        public string? ProfilePhoto { get; set; }
    }

}
