using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace services.Models.UsuarioModel
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
                if (string.IsNullOrWhiteSpace(value) || !EhEmailValido(value))
                    throw new ArgumentException("E-mail inválido", nameof(Email));

                _email = value;
            }
        }
        public string TipoDocumento { get; set; }
        private string _numeroDocumento;

        private const int CPF_LENGTH = 11;
        private const int CNPJ_LENGTH = 14;
        public string NumeroDocumento
        {
            get => _numeroDocumento;
            set
            {
                string documentoLimpo = new string(value.Where(char.IsDigit).ToArray());
                bool ehValido = false;

                if (documentoLimpo.Length == CPF_LENGTH)
                {
                    ehValido = EhCpf(documentoLimpo);
                }
                else if (documentoLimpo.Length == CNPJ_LENGTH)
                {
                    ehValido = EhCnpj(documentoLimpo);
                }

                if (ehValido)
                {
                    _numeroDocumento = documentoLimpo;
                }
                else
                {
                    throw new ArgumentException("Documento inválido", nameof(NumeroDocumento));
                }
            }
        }

        public string SenhaHash { get; set; }
        public StatusUsuario Status { get; set; } = StatusUsuario.Ativo;
        public enum StatusUsuario
        {
            Inativo = 0,
            Ativo = 1
        }
        public DateTime DataCriacao { get; set; }
        public int? GerenteId { get; set; }

        public bool EhEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //TODO: Implementear validador de cpf
        public static bool EhCpf(string cpf)
        {
            return true;
        }

        //TODO: Implementear validador de cpf
        public static bool EhCnpj(string cpf)
        {
            return true;
        }

    }
}