using Domain.Entities;

namespace Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Permisos.Any())
            {
                var permisos = new[]
                {
                    new Permiso { Nombre = "crear_anuncio" },
                    new Permiso { Nombre = "ver_anuncio" },
                    new Permiso { Nombre = "editar_anuncio" },
                    new Permiso { Nombre = "eliminar_anuncio" }
                };

                context.Permisos.AddRange(permisos);
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                var rolAdmin = new Rol { Nombre = "Admin" };
                context.Roles.Add(rolAdmin);
                context.SaveChanges();

                // Asignar todos los permisos al rol Admin
                var asignaciones = context.Permisos
                    .Select(p => new AsignacionPermiso
                    {
                        RolId = rolAdmin.Id,
                        PermisoId = p.Id
                    }).ToList();

                context.AsignacionesPermisos.AddRange(asignaciones);
                context.SaveChanges();
            }

            if (!context.Usuarios.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Administrador",
                    Email = "admin@demo.com",
                    Contrasena = "admin123"
                };

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                // Asignar rol admin al usuario
                var rolAdmin = context.Roles.First(r => r.Nombre == "Admin");

                var asignacion = new AsignacionRol
                {
                    UsuarioId = usuario.Id,
                    RolId = rolAdmin.Id
                };

                context.AsignacionesRoles.Add(asignacion);
                context.SaveChanges();
            }
        }
    }
}
