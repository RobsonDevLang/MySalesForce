using Microsoft.EntityFrameworkCore;
using usersService.Models;
using usersService.Services;

namespace usersService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<UsuarioModel> usuario { get; set; }
        public DbSet<Test> Teste { get; set; }
    }
}