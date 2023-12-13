using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public interface IUserService
    {
        IList<IdentityUser> GetAllUsers();
        Task<IList<IdentityUser>> GetAllUsersAsync();
    }
}
