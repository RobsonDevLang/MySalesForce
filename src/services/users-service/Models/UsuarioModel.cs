using System;
using System.Linq;
using usersService.Validators;

namespace usersService.Models
{
public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !UsuarioValidator.EhEmailValido(value))
                    throw new ArgumentException("E-mail inválido", nameof(Email));

                _email = value;
            }
        }

        public string TipoDocumento { get; set; }

        private string _numeroDocumento;
        public string NumeroDocumento
        {
            get => _numeroDocumento;
            set
            {
                if (!UsuarioValidator.ValidarDocumento(value, out var documentoLimpo))
                    throw new ArgumentException("Documento inválido", nameof(NumeroDocumento));

                _numeroDocumento = documentoLimpo;
            }
        }

        public string SenhaHash { get; set; }
        public UsuarioStatus Status { get; set; } = UsuarioStatus.Ativo;
        public DateTime DataCriacao { get; set; }
        public int? GerenteId { get; set; }

    }
}