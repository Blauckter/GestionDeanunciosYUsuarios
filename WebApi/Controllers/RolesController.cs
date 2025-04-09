using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _rolService.ObtenerTodosAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rol = await _rolService.ObtenerPorIdAsync(id);
            if (rol == null) return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rol rol)
        {
            var creado = await _rolService.CrearAsync(rol);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rol rol)
        {
            var actualizado = await _rolService.ActualizarAsync(id, rol);
            return actualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _rolService.EliminarAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
