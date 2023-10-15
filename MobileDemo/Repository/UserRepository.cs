using Microsoft.EntityFrameworkCore;
using MobileDemo.Authentication;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly MobileStoreContext _context;

        public UserRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUserAsync(Guid id, UserModel user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return false;
            }

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> GetUserByUserName(string userName, string Password)
        {
           return await _context.Users.Where(UserModel=>UserModel.UserName==userName && UserModel.Password == Password).FirstOrDefaultAsync();
        }
    }
}
