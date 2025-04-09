using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnunciosController : ControllerBase
    {
        private readonly IAnuncioService _anuncioService;

        public AnunciosController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        [HttpGet]
        [Authorize]
        [Permiso("ver_anuncio")]
        public async Task<IActionResult> Get()
        {
            var anuncios = await _anuncioService.ObtenerTodosAsync();
            return Ok(anuncios);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Permiso("ver_anuncio")]
        public async Task<IActionResult> Get(int id)
        {
            var anuncio = await _anuncioService.ObtenerPorIdAsync(id);
            if (anuncio == null) return NotFound();
            return Ok(anuncio);
        }

        [HttpPost]
        [Authorize]
        [Permiso("crear_anuncio")]
        public async Task<IActionResult> Post([FromBody] Anuncio anuncio)
        {
            var creado = await _anuncioService.CrearAsync(anuncio);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Permiso("editar_anuncio")]
        public async Task<IActionResult> Put(int id, [FromBody] Anuncio anuncio)
        {
            var actualizado = await _anuncioService.ActualizarAsync(id, anuncio);
            return actualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Permiso("eliminar_anuncio")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _anuncioService.EliminarAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
