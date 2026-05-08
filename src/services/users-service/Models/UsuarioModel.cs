using System;
using System.Linq;
using usersService.Validators;

namespace usersService.Models
{
public class UsuarioModel
    {

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
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
    
    public string SenhaHash { get; set; }
    public int  Status { get; set; } = 1;
    public DateTime DataCriacao { get; set; }
    public int? GerenteId { get; set; }
    public int? CargoId { get; set; }
    public int? DepartamentoId { get; set; }

    }
}