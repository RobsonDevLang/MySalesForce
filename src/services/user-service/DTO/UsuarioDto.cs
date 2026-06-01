using User.Models;

namespace User.DTO
{
public class UserDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int Status { get; set; } = 1; // Ativo por padrão
    public int? ManagerId { get; set; }
    public int? PositionId { get; set; }
    public int? DepartmentId { get; set; }

}
}