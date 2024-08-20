using StreetVendorsInEvents.Models;

namespace StreetVendorsInEvents.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<List<User>> SearchAllUsers();
        Task<bool> Delete(int id);
    }
}
