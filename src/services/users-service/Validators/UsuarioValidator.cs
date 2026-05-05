using System;
using System.Linq;
using System.Net.Mail;

namespace usersService.Validators
{
    public static class UsuarioValidator
    {
        public static bool EhEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarDocumento(string documento, out string documentoLimpo)
        {
            documentoLimpo = string.Empty;
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            var digitos = new string(documento.Where(char.IsDigit).ToArray());
            if (digitos.Length == 11 && EhCpf(digitos))
            {
                documentoLimpo = digitos;
                return true;
            }

            if (digitos.Length == 14 && EhCnpj(digitos))
            {
                documentoLimpo = digitos;
                return true;
            }

            return false;
        }

        //TODO: Implementar validação de CPF
        public static bool EhCpf(string cpf)
        {
            return true;
        }

        //TODO: Implementar validação de CNPJ
        public static bool EhCnpj(string cnpj)
        {
            return true;
        }
    }
}
