using System;
using User.DTO;
using User.Models;

namespace User.Mappers
{
public static class UsuarioMapper
{
    public static UserModel ParaModel(UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new UserModel
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Phone = dto.Phone,
            PasswordHash = dto.password_hash,
            Status = dto.Status,
            CreatedDate = DateTime.UtcNow,
            ManagerId = dto.ManagerId,
            PositionId = dto.PositionId,
            DepartmentId = dto.DepartmentId
        };
    }

    public static UserDto ForDto(UserModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        return new UserDto
        {
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            Phone = model.Phone,
            password_hash = model.PasswordHash,
            Status = model.Status,
            ManagerId = model.ManagerId,
            PositionId = model.PositionId,
            DepartmentId = model.DepartmentId
        };
    }
}
}
