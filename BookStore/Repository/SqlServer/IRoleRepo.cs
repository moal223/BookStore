using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository.SqlServer
{
    public interface IRoleRepo
    {
        IList<IdentityRole> GetAllRoles();
        Task<IList<IdentityRole>> GetAllRolesAsync();
    }
}
