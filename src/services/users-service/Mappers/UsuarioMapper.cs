using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using services.DTO;
using services.Models.UsuarioModel;

namespace services.Mappers
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
            Status = (UsuarioModel.StatusUsuario)dto.Status,
            DataCriacao = DateTime.Now,
            GerenteId = dto.GerenteId
        };
    }
}
}