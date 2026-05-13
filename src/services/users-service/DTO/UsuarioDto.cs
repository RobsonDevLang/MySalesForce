using usersService.Models;

namespace usersService.DTO
{
public class UsuarioDto
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public int Status { get; set; } = 1; // Ativo por padrão
    public int? GerenteId { get; set; }
    public int? CargoId { get; set; }
    public int? DepartamentoId { get; set; }
}
}