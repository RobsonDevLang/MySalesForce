using System;
using System.Linq;
using User.Validators;

namespace User.Models
{
public class UserModel
    {

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !UserValidator.IsEmailValid(value))
                    throw new ArgumentException("E-mail inválido", nameof(Email));

                _email = value;
            }
        }
    
    public string PasswordHash { get; set; } = string.Empty;
    public int  Status { get; set; } = 1;
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public int? ManagerId { get; set; }
    public int? PositionId { get; set; }
    public int? DepartmentId { get; set; }

    // public UserModel? Gerente { get; set; }
    // public CargoModel? Cargo { get; set; }
    // public DepartamentoModel? Departamento { get; set; }

    }
}