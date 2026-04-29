using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace services.DTO
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string SenhaHash { get; set; }
        public int Status { get; set; }
        public int? GerenteId { get; set; }
    }
}