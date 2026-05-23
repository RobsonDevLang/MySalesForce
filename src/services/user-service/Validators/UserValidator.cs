using System;
using System.Linq;
using System.Net.Mail;

namespace User.Validators
{
    public static class UserValidator
    {
        public static bool IsEmailValid(string email)
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

        public static bool ValidateDocument(string documento, out string cleanDocument)
        {
            cleanDocument = string.Empty;
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            var digits = new string(documento.Where(char.IsDigit).ToArray());
            if (digits.Length == 11 && IsCpf(digits))
            {
                cleanDocument = digits;
                return true;
            }

            if (digits.Length == 14 && IsCnpj(digits))
            {
                cleanDocument = digits;
                return true;
            }

            return false;
        }

        //TODO: Implementar validação de CPF
        public static bool IsCpf(string cpf)
        {
            return true;
        }

        //TODO: Implementar validação de CNPJ
        public static bool IsCnpj(string cnpj)
        {
            return true;
        }
    }
}
