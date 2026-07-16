using User.Models;

namespace User.Services
{
    public interface IUserService
    {
        IReadOnlyList<UserModel> GetAll();
        UserModel? GetById(int id);
        UserModel Add(UserModel user);
        void Update(UserModel user);
        UserModel? Login(string email, string password);
        UserModel? GetByEmail(string email);
    }
}
