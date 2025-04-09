using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Permiso> Permisos => Set<Permiso>();
        public DbSet<AsignacionRol> AsignacionesRoles => Set<AsignacionRol>();
        public DbSet<AsignacionPermiso> AsignacionesPermisos => Set<AsignacionPermiso>();
        public DbSet<Anuncio> Anuncios => Set<Anuncio>();
    }
}
