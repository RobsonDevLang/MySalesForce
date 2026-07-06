using User.Models;

namespace User.Repositories
{
    public interface IUserRepository
    {
        IReadOnlyList<UserModel> GetAll();
        UserModel? GetById(int id);
        UserModel Add(UserModel user);
        void Update(UserModel user);
        bool ExistsByEmail(string email);
    }
}
