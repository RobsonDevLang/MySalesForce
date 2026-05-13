using System;
using UserService.DTO;
using UserService.Models;

namespace UserService.Mappers
{
public static class UsuarioMapper
{
    public static UserModel ParaModel(UserDto dto)
    {
        return new UserModel
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            PasswordHash = dto.PasswordHash,
            Status = dto.Status,
            CreateDate = DateTime.UtcNow,
            ManagerId = dto.ManagerId,
            PositionId = dto.PositionId,
            DepartmentId = dto.DepartmentId
        };
    }

    public static UserDto ForDto(UserModel model)
    {
        return new UserDto
        {
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            PasswordHash = model.PasswordHash,
            Status = model.Status,
            ManagerId = model.ManagerId,
            PositionId = model.PositionId,
            DepartmentId = model.DepartmentId
        };
    }
}
}
