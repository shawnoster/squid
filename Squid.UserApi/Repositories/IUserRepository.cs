using Squid.UserApi.Entities;

namespace Squid.UserApi.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        
        User? GetUser(Guid id);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(Guid id);
    }
}