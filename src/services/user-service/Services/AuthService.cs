using User.DTO;
using User.Mappers;

namespace User.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthService(
            IUserService userService,
            IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public LoginResponseDto? Login(LoginDto dto)
        {
            var user = _userService.Login(dto.Email, dto.Password_hash);

            if (user == null)
                return null;

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                User = UsuarioMapper.ForDto(user)
            };
        }
    }
}