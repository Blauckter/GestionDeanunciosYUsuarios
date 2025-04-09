using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Anuncios)
                .Include(u => u.Asignaciones)
                .ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Anuncios)
                .Include(u => u.Asignaciones)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> CrearAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ActualizarAsync(int id, Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return false;

            existente.Nombre = usuario.Nombre;
            existente.Email = usuario.Email;
            existente.Contrasena = usuario.Contrasena;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Anuncios)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null) return false;

            usuario.Eliminado = true;

            foreach (var anuncio in usuario.Anuncios ?? new List<Anuncio>())
            {
                anuncio.UsuarioEliminado = true;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
