using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class RolService : IRolService
    {
        private readonly AppDbContext _context;

        public RolService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> ObtenerTodosAsync()
        {
            return await _context.Roles
                .Include(r => r.Permisos)
                .ToListAsync();
        }

        public async Task<Rol?> ObtenerPorIdAsync(int id)
        {
            return await _context.Roles
                .Include(r => r.Permisos)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rol> CrearAsync(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<bool> ActualizarAsync(int id, Rol rol)
        {
            var existente = await _context.Roles.FindAsync(id);
            if (existente == null) return false;

            existente.Nombre = rol.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var rol = await _context.Roles
                .Include(r => r.Permisos)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rol == null) return false;

            // Eliminar asignaciones de permisos
            _context.AsignacionesPermisos.RemoveRange(rol.Permisos ?? new List<AsignacionPermiso>());
            _context.Roles.Remove(rol);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
