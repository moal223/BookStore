using BookStore.Repository.SqlServer;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public IList<IdentityRole> GetAllRoles() =>
            _roleRepo.GetAllRoles();
        public async Task<IList<IdentityRole>> GetAllRolesAsync() => await _roleRepo.GetAllRolesAsync();
    }
}
