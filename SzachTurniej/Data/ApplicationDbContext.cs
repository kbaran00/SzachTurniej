using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SzachTurniej.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentRound> TournamentRounds { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TournamentStandings> TournamentStandings { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            SeedRoles(modelBuilder);

            // Seed default admin user
            SeedAdminUser(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );
        }

        private void SeedAdminUser(ModelBuilder modelBuilder)
        {
            ApplicationUser adminUser = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@admin.pl",
                NormalizedUserName = "ADMIN@ADMIN.PL",
                Email = "admin@admin.pl",
                NormalizedEmail = "ADMIN@ADMIN.PL",
                EmailConfirmed = true,
                Name = "Admin",
                Surname = "Admin",
                ProfilePhoto = "default.jpg"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "admin@123");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" }
            );
        }
    }
}
