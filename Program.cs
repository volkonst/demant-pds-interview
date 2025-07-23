using Microsoft.Extensions.Caching.Memory;

namespace Demant.Interview.CodeReview
{
    public class User
    {
        public string Name { get; set; }
        public DateTime? LastLogin { get; set; }
    }

    public interface IUserRepository
    {
        Task CreateUser(string name);
    }

    public class UserRepository : IUserRepository
    {
        private IDictionary<string, User> _users = new Dictionary<string, User>();

        public Task CreateUser(string name)
        {
            if (_users.ContainsKey(name))
            {
                throw new Exception("User already exist");
            }

            User user = new User
            {
                Name = name
            };

            _users.Add(name, user);
            return Task.CompletedTask;
        }
    }

    public static class App
    {
    }

}