using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/asignaciones")]
    public class AsignacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsignacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("permiso")]
        public async Task<IActionResult> AsignarPermisoARol([FromBody] AsignacionPermiso asignacion)
        {
            // Validar si ya existe
            var existe = _context.AsignacionesPermisos.Any(a =>
                a.RolId == asignacion.RolId && a.PermisoId == asignacion.PermisoId);

            if (existe)
                return Conflict("El permiso ya está asignado a ese rol.");

            _context.AsignacionesPermisos.Add(asignacion);
            await _context.SaveChangesAsync();
            return Ok(asignacion);
        }

        [HttpPost("rol")]
        public async Task<IActionResult> AsignarRolAUsuario([FromBody] AsignacionRol asignacion)
        {
            var existe = _context.AsignacionesRoles.Any(a =>
                a.RolId == asignacion.RolId && a.UsuarioId == asignacion.UsuarioId);

            if (existe)
                return Conflict("El rol ya está asignado al usuario.");

            _context.AsignacionesRoles.Add(asignacion);
            await _context.SaveChangesAsync();
            return Ok(asignacion);
        }
    }
}
