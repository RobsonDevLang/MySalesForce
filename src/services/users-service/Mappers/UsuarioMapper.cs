using System;
using usersService.DTO;
using usersService.Models;

namespace usersService.Mappers
{
public static class UsuarioMapper
{
    public static UsuarioModel ParaModel(UsuarioDto dto)
    {
        return new UsuarioModel
        {
            Nome = dto.Nome,
            Sobrenome = dto.Sobrenome,
            Email = dto.Email,
            SenhaHash = dto.SenhaHash,
            Status = dto.Status,
            DataCriacao = DateTime.UtcNow,
            GerenteId = dto.GerenteId,
            CargoId = dto.CargoId,
            DepartamentoId = dto.DepartamentoId
        };
    }

    public static UsuarioDto ParaDto(UsuarioModel model)
    {
        return new UsuarioDto
        {
            Nome = model.Nome,
            Sobrenome = model.Sobrenome,
            Email = model.Email,
            SenhaHash = model.SenhaHash,
            Status = model.Status,
            GerenteId = model.GerenteId,
            CargoId = model.CargoId,
            DepartamentoId = model.DepartamentoId
        };
    }
}
}
