using Microsoft.AspNetCore.Mvc;
using usersService.DTO;
using usersService.Mappers;
using usersService.Models;
using usersService.Services;
using usersService.Validators;
using System.Net.Mail;
using Microsoft.AspNetCore.JsonPatch;
using usersService.Data;
using System.Data.Common;

namespace usersService.Controllers;

[ApiController]
[Route("usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly ApplicationDbContext _context;

    public UsuariosController(IUsuarioService service, ApplicationDbContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.ObterTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var usuario = _service.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult Create(UsuarioDto dto)
    {
        var usuarioMapeado = UsuarioMapper.ParaModel(dto);
        var usuarioCriado = _service.Adicionar(usuarioMapeado);

        _context.usuario.Add(usuarioCriado);
        _context.SaveChanges();

        return Ok("Criado com sucesso");
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UsuarioDto dto)
    {
        var usuarioExistente = _service.ObterPorId(id);
        if (usuarioExistente == null)
            return NotFound();

        var usuarioAtualizado = UsuarioMapper.ParaModel(dto);
        usuarioAtualizado.Id = id;

        _service.Atualizar(usuarioAtualizado);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, JsonPatchDocument<UsuarioDto> patchDoc)
    {
        var usuarioExistente = _service.ObterPorId(id);
        if (usuarioExistente == null)
            return NotFound();

        var dto = UsuarioMapper.ParaDto(usuarioExistente);
        patchDoc.ApplyTo(dto);

        var usuarioAtualizado = UsuarioMapper.ParaModel(dto);
        usuarioAtualizado.Id = id;

        _service.Atualizar(usuarioAtualizado);

        return NoContent();
    }

}


