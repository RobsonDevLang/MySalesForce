using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        IReadOnlyList<UserModel> GetAll();
        UserModel? GetById(int id);
        UserModel Add(UserModel user);
        void Update(UserModel user);
    }
}
