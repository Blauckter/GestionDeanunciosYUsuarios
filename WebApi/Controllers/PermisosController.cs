using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisoService _permisoService;

        public PermisosController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permisos = await _permisoService.ObtenerTodosAsync();
            return Ok(permisos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permiso = await _permisoService.ObtenerPorIdAsync(id);
            if (permiso == null) return NotFound();
            return Ok(permiso);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permiso permiso)
        {
            var creado = await _permisoService.CrearAsync(permiso);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Permiso permiso)
        {
            var actualizado = await _permisoService.ActualizarAsync(id, permiso);
            return actualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _permisoService.EliminarAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
