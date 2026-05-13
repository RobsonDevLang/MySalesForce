using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
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
    }
}