using Microsoft.AspNetCore.Mvc;
namespace mySalesForceApi.Controllers{
    
    [ApiController]
    [Route("[controller]")]
    public class Usuario : ControllerBase
    {
        [HttpGet]
        public IActionResult SelecionarTodos()
        {
            var clientes = 1;
            return Ok(clientes);
        }
        
    }
    
    
}


