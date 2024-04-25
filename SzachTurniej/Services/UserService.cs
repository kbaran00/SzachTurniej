using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SzachTurniej.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SzachTurniej.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _userManager = userManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<List<(ApplicationUser user, string role)>> GetAllUsersWithRolesAsync()
        {
            var usersWithRoles = new List<(ApplicationUser, string)>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                usersWithRoles.Add((user, role));
            }

            return usersWithRoles;
        }

        public async Task<bool> SetAdminRole(string id)
        {
            // Sprawdzamy czy id użytkownika to nie aktualnie zalogowany użytkownik lub admin, jeżeli tak to przerywamy operację
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var currentUserState = authState.User;
            if (currentUserState.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(currentUserState);
                if (currentUser.Id == id || id == "1") // Id 1 to admin
                {
                    return false;
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, "User");
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> SetUserRole(string id)
        {
            // Sprawdzamy czy id użytkownika to nie aktualnie zalogowany użytkownik lub admin, jeżeli tak to przerywamy operację
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var currentUserState = authState.User;
            if (currentUserState.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(currentUserState);
                if (currentUser.Id == id || id == "1") // Id 1 to admin
                {
                    return false;
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, "Admin");
                        await _userManager.AddToRoleAsync(user, "User");
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}