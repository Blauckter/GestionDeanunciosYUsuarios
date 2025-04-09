using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PermisoService : IPermisoService
    {
        private readonly AppDbContext _context;

        public PermisoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permiso>> ObtenerTodosAsync()
        {
            return await _context.Permisos.ToListAsync();
        }

        public async Task<Permiso?> ObtenerPorIdAsync(int id)
        {
            return await _context.Permisos.FindAsync(id);
        }

        public async Task<Permiso> CrearAsync(Permiso permiso)
        {
            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();
            return permiso;
        }

        public async Task<bool> ActualizarAsync(int id, Permiso permiso)
        {
            var existente = await _context.Permisos.FindAsync(id);
            if (existente == null) return false;

            existente.Nombre = permiso.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null) return false;

            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
