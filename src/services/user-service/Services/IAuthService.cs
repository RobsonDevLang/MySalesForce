using User.DTO;

namespace User.Services
{
    public interface IAuthService
    {
        LoginResponseDto? Login(LoginDto dto);
    }
}