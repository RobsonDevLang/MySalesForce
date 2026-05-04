using System.Collections.Generic;
using usersService.Models;

namespace usersService.Services
{
    public interface IUsuarioService
    {
        IReadOnlyList<UsuarioModel> ObterTodos();
        UsuarioModel? ObterPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuario);
    }
}
