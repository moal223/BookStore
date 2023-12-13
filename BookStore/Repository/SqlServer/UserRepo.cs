using BookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository.SqlServer
{
    public class UserRepo : IUserRepo
    {
        AppDbContext _context;
        public UserRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        public IList<IdentityUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public async Task<IList<IdentityUser>> GetAllUsersAsync()
        {
            return await Task.Run(() => GetAllUsers());
        }
    }
}
