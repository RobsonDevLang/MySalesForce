using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Models;

namespace User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<UserModel> GetAll()
        {
            return _context.AppUser
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public UserModel? GetById(int id)
        {
            return _context.AppUser
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id);
        }

        public UserModel Add(UserModel user)
        {
            _context.AppUser.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Update(UserModel user)
        {
            _context.AppUser.Update(user);
            _context.SaveChanges();
        }

        public UserModel? GetByEmail(string email)
        {
            return _context.AppUser
                .FirstOrDefault(x => x.Email == email);
        }

        public bool ExistsByEmail(string email)
        {
            return _context.AppUser.Any(x => x.Email == email);
        }
    }
}