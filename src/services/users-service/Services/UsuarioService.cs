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
                Nome = "John Doe",
                Email = "john.doe@example.com",
                TipoDocumento = "CPF",
                NumeroDocumento = "123.456.789-00",
                SenhaHash = "123456",
                Status = UsuarioStatus.Ativo,
                DataCriacao = DateTime.Now,
                GerenteId = 1,
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
            usuario.Id = _usuarios.Any() ? _usuarios.Max(u => u.Id) + 1 : 1;
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
