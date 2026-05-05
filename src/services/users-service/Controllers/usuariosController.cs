using Microsoft.AspNetCore.Mvc;
using usersService.DTO;
using usersService.Mappers;
using usersService.Models;
using usersService.Services;
using usersService.Validators;
using System.Net.Mail;
using Microsoft.AspNetCore.JsonPatch;

namespace usersService.Controllers;

[ApiController]
[Route("usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuariosController(IUsuarioService service)
    {
        _service = service;
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
        var usuario = UsuarioMapper.ParaModel(dto);
        var usuarioCriado = _service.Adicionar(usuario);

        return CreatedAtAction(nameof(GetById), new { id = usuarioCriado.Id }, usuarioCriado);
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


