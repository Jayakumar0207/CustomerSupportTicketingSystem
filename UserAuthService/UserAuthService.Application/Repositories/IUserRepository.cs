using UserAuthService.Domain.Entities;

namespace UserAuthService.Application.Repositories
{
    public interface IUserRepository
    {
        bool RegisterUser(User user);
        IEnumerable<User> GetAll();
        User GetUserByEmail(string email);
    }
}
