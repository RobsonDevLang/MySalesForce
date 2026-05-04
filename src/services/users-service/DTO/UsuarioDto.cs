using usersService.Models;

namespace usersService.DTO
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string SenhaHash { get; set; }
        public UsuarioStatus Status { get; set; }
        public int? GerenteId { get; set; }
    }
}