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

        public UserModel Add(UserModel user) =>
            _repository.Add(user);

        public void Update(UserModel user) =>
            _repository.Update(user);
    }
}