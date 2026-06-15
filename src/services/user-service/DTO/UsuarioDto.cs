using User.Models;

namespace User.DTO
{
public class UserDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string password_hash { get; set; } = string.Empty;
    public UserStatus  Status { get; set; } = UserStatus.Active; // Ativo por padrão
    public int? ManagerId { get; set; }
    public int? PositionId { get; set; }
    public int? DepartmentId { get; set; }
    public int? RoleId { get; set; }
}
}