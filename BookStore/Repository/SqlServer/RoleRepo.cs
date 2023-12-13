using BookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository.SqlServer
{
    public class RoleRepo : IRoleRepo
    {
        private readonly AppDbContext _context;
        public RoleRepo(AppDbContext context)
        {
            _context = context;
        }
        public IList<IdentityRole> GetAllRoles()
        => _context.Roles.ToList();
        public async Task<IList<IdentityRole>> GetAllRolesAsync()
        => await Task.Run(() => GetAllRoles());
    }
}
