using User.Models;

namespace User.DTO
{
public class UserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int Status { get; set; } = 1; // Ativo por padrão
    public int? ManagerId { get; set; }
    public int? PositionId { get; set; }
    public int? DepartmentId { get; set; }

}
}