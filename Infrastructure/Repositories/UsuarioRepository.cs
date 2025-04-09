using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) => _context = context;

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.Include(u => u.Anuncios).FirstOrDefaultAsync(u => u.Id == id);
            if (usuario != null)
            {
                // Marcar como eliminado
                usuario.Eliminado = true;

                // Marcar sus anuncios
                if (usuario.Anuncios != null)
                {
                    foreach (var anuncio in usuario.Anuncios)
                        anuncio.UsuarioEliminado = true;
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync() =>
            await _context.Usuarios.Include(u => u.Anuncios).ToListAsync();

        public async Task<Usuario?> GetByIdAsync(int id) =>
            await _context.Usuarios.Include(u => u.Anuncios).FirstOrDefaultAsync(u => u.Id == id);

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
