using BookStore.Repository.SqlServer;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo) {
            _userRepo = userRepo;
        }
        public IList<IdentityUser> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
        public async Task<IList<IdentityUser>> GetAllUsersAsync()
        {
            return await _userRepo.GetAllUsersAsync();
        }
    }
}
