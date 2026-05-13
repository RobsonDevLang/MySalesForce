using System;
using System.Linq;
using usersService.Validators;

namespace usersService.Models
{
public class UsuarioModel
    {

    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    private string _email = string.Empty;
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
    
    public string SenhaHash { get; set; } = string.Empty;
    public int  Status { get; set; } = 1;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public int? GerenteId { get; set; }
    public int? CargoId { get; set; }
    public int? DepartamentoId { get; set; }

    // public UsuarioModel? Gerente { get; set; }
    // public CargoModel? Cargo { get; set; }
    // public DepartamentoModel? Departamento { get; set; }

    }
}