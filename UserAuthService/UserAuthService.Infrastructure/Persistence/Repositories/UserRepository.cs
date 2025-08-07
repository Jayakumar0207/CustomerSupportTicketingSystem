using UserAuthService.Application.Repositories;
using UserAuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserAuthService.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        AuthServiceDBContext _db;
        public UserRepository(AuthServiceDBContext db)
        {
            _db = db;
        }
        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email)!;
        }

        public bool RegisterUser(User user)
        {
            if (user != null)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
