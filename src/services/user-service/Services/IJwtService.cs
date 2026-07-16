using User.Models;

namespace User.Services;

public interface IJwtService
{
    string GenerateToken(UserModel user);
}