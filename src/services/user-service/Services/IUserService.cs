using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        IReadOnlyList<UserModel> GetAll();
        UserModel? GetById(int id);
        UserModel Add(UserModel user);
        void Update(UserModel user);
    }
}
