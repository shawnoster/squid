using Squid.UserApi.Entities;

namespace Squid.UserApi.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User { Id = Guid.NewGuid(), Name = "Chaos", CreatedDate = DateTimeOffset.UtcNow },
            new User { Id = Guid.NewGuid(), Name = "Creamsicle", CreatedDate = DateTimeOffset.UtcNow },
            new User { Id = Guid.NewGuid(), Name = "Richa", CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User? GetUser(Guid id)
        {
            return this?.users.Where(user => user.Id == id).SingleOrDefault();
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == user.Id);
            users[index] = user;
        }

        public void DeleteUser(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
        }
    }
}