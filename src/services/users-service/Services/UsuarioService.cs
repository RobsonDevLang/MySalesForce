using System.Collections.Generic;
using System.Linq;
using usersService.Models;

namespace usersService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private static readonly List<UsuarioModel> _usuarios = new()
        {
            new UsuarioModel
            {
                Id = 1,
                Nome = "John",
                Sobrenome = "Doe",
                Email = "john.doe@example.com",
                SenhaHash = "123456",
                Status = 1,
                DataCriacao = DateTime.UtcNow,
                GerenteId = null,
                CargoId = 1,
                DepartamentoId = 1
            }
        };

        public IReadOnlyList<UsuarioModel> ObterTodos()
        {
            return _usuarios.AsReadOnly();
        }

        public UsuarioModel? ObterPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _usuarios.Add(usuario);

            return usuario;
        }

        public void Atualizar(UsuarioModel usuario)
        {
            var index = _usuarios.FindIndex(u => u.Id == usuario.Id);
            if (index != -1)
            {
                _usuarios[index] = usuario;
            }
        }

    }
}
