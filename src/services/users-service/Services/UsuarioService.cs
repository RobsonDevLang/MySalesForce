using usersService.Models;
using usersService.Repositories;

namespace usersService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<UsuarioModel> ObterTodos() =>
            _repository.ObterTodos();

        public UsuarioModel? ObterPorId(int id) =>
            _repository.ObterPorId(id);

        public UsuarioModel Adicionar(UsuarioModel usuario) =>
            _repository.Adicionar(usuario);

        public void Atualizar(UsuarioModel usuario) =>
            _repository.Atualizar(usuario);
    }
}