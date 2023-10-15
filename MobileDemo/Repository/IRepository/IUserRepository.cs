using MobileDemo.Authentication;

namespace MobileDemo.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserByIdAsync(Guid id);
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(Guid id, UserModel user);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserModel> GetUserByUserName(string userName, string Password);
    }
}
