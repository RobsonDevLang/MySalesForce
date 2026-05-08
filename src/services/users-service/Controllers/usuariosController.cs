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

// Controllers/UsuariosController.cs
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
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult Create(UsuarioDto dto)
    {
        var model = UsuarioMapper.ParaModel(dto);
        var criado = _service.Adicionar(model);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UsuarioDto dto)
    {
        if (_service.ObterPorId(id) == null) return NotFound();

        var model = UsuarioMapper.ParaModel(dto);
        model.Id = id;
        _service.Atualizar(model);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, JsonPatchDocument<UsuarioDto> patchDoc)
    {
        var existente = _service.ObterPorId(id);
        if (existente == null) return NotFound();

        var dto = UsuarioMapper.ParaDto(existente);
        patchDoc.ApplyTo(dto);

        var model = UsuarioMapper.ParaModel(dto);
        model.Id = id;
        _service.Atualizar(model);
        return NoContent();
    }
}