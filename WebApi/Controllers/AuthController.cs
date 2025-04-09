using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Asignaciones!)
                    .ThenInclude(ar => ar.Rol!)
                        .ThenInclude(r => r.Permisos!)
                            .ThenInclude(ap => ap.Permiso)
                .FirstOrDefaultAsync(u => u.Email == login.Usuario && u.Contrasena == login.Contrasena);

            if (usuario == null)
                return Unauthorized("Credenciales inválidas");

            // Obtener todos los permisos del usuario segun sus roles
            var permisos = usuario.Asignaciones?
                .SelectMany(a => a.Rol?.Permisos ?? new List<AsignacionPermiso>())
                .Select(p => p.Permiso?.Nombre)
                .Where(nombre => !string.IsNullOrWhiteSpace(nombre))
                .Select(nombre => nombre!)
                .Distinct()
                .ToList() ?? new List<string>();

            var token = _jwtService.GenerateToken(usuario, permisos!);

            return Ok(new { token });
        }
    }

    public class LoginDto
    {
        public string Usuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}
