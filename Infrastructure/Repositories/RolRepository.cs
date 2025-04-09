using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _context;
        public RolRepository(AppDbContext context) => _context = context;

        public async Task<Rol> AddAsync(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Roles
                .Include(r => r.Permisos)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rol != null)
            {
                // Eliminar asignaciones de permisos
                _context.AsignacionesPermisos.RemoveRange(rol.Permisos ?? new List<AsignacionPermiso>());
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rol>> GetAllAsync() =>
            await _context.Roles.Include(r => r.Permisos).ToListAsync();

        public async Task<Rol?> GetByIdAsync(int id) =>
            await _context.Roles.Include(r => r.Permisos).FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Rol> UpdateAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
            return rol;
        }
    }
}
