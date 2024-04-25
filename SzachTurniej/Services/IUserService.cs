using Microsoft.AspNetCore.Identity;
using SzachTurniej.Data;

namespace SzachTurniej.Services
{
    public interface IUserService
    {
        Task<List<(ApplicationUser user, string role)>> GetAllUsersWithRolesAsync();
        Task<bool> SetAdminRole(string id);
        Task<bool> SetUserRole(string id);
    }
}
