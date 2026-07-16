namespace User.DTO
{
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password_hash { get; set; } = string.Empty;
    }
}