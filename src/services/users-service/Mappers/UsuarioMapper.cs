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
                Email = dto.Email,
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                SenhaHash = dto.SenhaHash,
                Status = dto.Status,
                DataCriacao = DateTime.Now,
                GerenteId = dto.GerenteId
            };
        }

        public static UsuarioDto ParaDto(UsuarioModel model)
        {
            return new UsuarioDto
            {
                Nome = model.Nome,
                Email = model.Email,
                TipoDocumento = model.TipoDocumento,
                NumeroDocumento = model.NumeroDocumento,
                SenhaHash = model.SenhaHash,
                Status = model.Status,
                GerenteId = model.GerenteId
            };
        }
    }
}
