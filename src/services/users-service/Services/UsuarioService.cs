using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using services.Models.UsuarioModel;

namespace services.Services
{
    public class UsuarioService
    {
        private static List<UsuarioModel> _usuarios = new List<UsuarioModel>
        {
            new UsuarioModel
            {
                Id = 1,
                Nome = "John Doe",
                Email = "john.doe@example.com",
                TipoDocumento = "CPF",
                NumeroDocumento = "123.456.789-00",
                SenhaHash = "123456",
                Status = UsuarioModel.StatusUsuario.Ativo,
                DataCriacao = DateTime.Now,
                GerenteId = 1,
            }
        };

        public List<UsuarioModel> ObterTodos()
        {
            return _usuarios;
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

    }
}