using usersService.Models;

namespace usersService.Repositories
{
    public interface IUsuarioRepository
    {
        IReadOnlyList<UsuarioModel> ObterTodos();
        UsuarioModel? ObterPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuario);
    }
}
