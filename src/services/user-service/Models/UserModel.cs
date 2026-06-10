using System;
using System.Linq;
using User.Validators;

namespace User.Models
{
public class UserModel
    {

    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Surname { get; set; } = string.Empty;
    private string _email = string.Empty;
        public required string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !UserValidator.IsEmailValid(value))
                    throw new ArgumentException("E-mail inválido", nameof(Email));

                _email = value;
            }
        }
    
    public required string PasswordHash { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    public int? DepartmentId { get; set; }
    public DepartmentModel? Department { get; set; }

    public int? PositionId { get; set; }
    public PositionModel? Position { get; set; }

    public int? RoleId { get; set; }
    public RoleModel? Role { get; set; }

    public int? ManagerId { get; set; }
    public UserModel? Manager { get; set; }
    
    public UserStatus Status { get; set; } = UserStatus.Active;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; }
    public DateTime? LastLoginDate { get; set; }

    }
}