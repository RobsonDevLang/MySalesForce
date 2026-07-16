using Microsoft.AspNetCore.Mvc;
using User.DTO;
using User.Mappers;
using User.Models;
using User.Services;
using User.Validators;
using System.Net.Mail;
using Microsoft.AspNetCore.JsonPatch;
using User.Data;
using System.Data.Common;
using BCrypt.Net;

namespace User.Controllers
{

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IAuthService _authService;

        public UserController(IUserService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _service.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(UserDto dto)
        {
            try
            {
                var model = UsuarioMapper.ParaModel(dto);
                model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.password_hash);
                var created = _service.Add(model);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserDto dto)
        {
            if (_service.GetById(id) == null) return NotFound();

            var model = UsuarioMapper.ParaModel(dto);
            model.Id = id;
            _service.Update(model);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, JsonPatchDocument<UserDto> patchDoc)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();

            var dto = UsuarioMapper.ForDto(existing);
            patchDoc.ApplyTo(dto);

            var model = UsuarioMapper.ParaModel(dto);
            model.Id = id;
            _service.Update(model);
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var response = _authService.Login(dto);

            if (response == null)
            {
                return Unauthorized(new
                {
                    message = "E-mail ou senha inválidos."
                });
            }

            return Ok(response);
        }
    }
}