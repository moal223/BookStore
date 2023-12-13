using BookStore.Repository.SqlServer;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public interface IRoleService
    {
        IList<IdentityRole> GetAllRoles();
        Task<IList<IdentityRole>> GetAllRolesAsync();
    }
}
