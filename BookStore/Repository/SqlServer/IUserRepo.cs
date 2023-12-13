using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository.SqlServer
{
    public interface IUserRepo
    {
        IList<IdentityUser> GetAllUsers();
        Task<IList<IdentityUser>> GetAllUsersAsync();
    }
}
