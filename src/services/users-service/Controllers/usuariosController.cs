using Microsoft.AspNetCore.Mvc;
using services.DTO;
using services.Models.UsuarioModel;
using services.Mappers;
using services.Services;

namespace mySalesForceApi.Controllers{
    
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController  : ControllerBase
    {
        // private readonly UsuarioContext _context;
        private readonly UsuarioService _service = new UsuarioService();

        // public UsuariosController(UsuarioContext context)
        // {
        //     _context = context;
        // }

        [HttpGet]
        public IActionResult ExibirTodosUsuarios()
        {
            return Ok(_service.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult SelecionarUsuario(int id)
        {
            var usuario = _service.ObterPorId(id);
            // var usuario = _usuarios.Usuario
            //     .Include(u => u.Usuario)
            //     .FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult AdicionarUsuario(UsuarioDto dto)
        {
            var usuario = UsuarioMapper.ParaModel(dto);
            var usuarioCriado = _service.Adicionar(usuario);

            return CreatedAtAction(nameof(SelecionarUsuario), new { id = usuarioCriado.Id }, usuarioCriado);
        }
        
    }
    
    
}


