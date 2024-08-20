using StreetVendorsInEvents.Data;
using StreetVendorsInEvents.Models;
using StreetVendorsInEvents.Repository.Interface;

namespace StreetVendorsInEvents.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext streetVendorsDbContext)
        {
            _dbContext = streetVendorsDbContext;
        }

        public async Task<User> Add(User user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> SearchAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
