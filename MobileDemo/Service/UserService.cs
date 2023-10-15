using MobileDemo.Authentication;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<UserModel> UpdateUserAsync(Guid id, UserModel user)
        {
            return await _userRepository.UpdateUserAsync(id, user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<UserModel> GetUserByUserName(string userName, string Password)
        {
            return await _userRepository.GetUserByUserName(userName, Password);
        }
    }
}
