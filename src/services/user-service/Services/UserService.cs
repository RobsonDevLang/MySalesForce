using User.Models;
using User.Repositories;

namespace User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<UserModel> GetAll() =>
            _repository.GetAll();

        public UserModel? GetById(int id) =>
            _repository.GetById(id);

        public UserModel Add(UserModel user)
        {
            var exists = _repository.ExistsByEmail(user.Email);

            if (exists)
                throw new InvalidOperationException("Usuário já existe.");

            return _repository.Add(user);
        }

        public void Update(UserModel user) =>
            _repository.Update(user);

        public UserModel? Login(string email, string password)
        {
            var user = _repository.GetByEmail(email);

            if (user == null)
                return null;

            var passwordIsValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!passwordIsValid)
                return null;

            return user;
        }

        public UserModel? GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }

}