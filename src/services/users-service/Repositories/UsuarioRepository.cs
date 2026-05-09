using Microsoft.EntityFrameworkCore;
using usersService.Data;
using usersService.Models;

namespace usersService.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<UsuarioModel> ObterTodos()
        {
            return _context.Usuario
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public UsuarioModel? ObterPorId(int id)
        {
            return _context.Usuario
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public void Atualizar(UsuarioModel usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}