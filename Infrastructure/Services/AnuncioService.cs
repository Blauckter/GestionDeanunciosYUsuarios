using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly AppDbContext _context;

        public AnuncioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anuncio>> ObtenerTodosAsync()
        {
            return await _context.Anuncios
                .Include(a => a.Usuario)
                .ToListAsync();
        }

        public async Task<Anuncio?> ObtenerPorIdAsync(int id)
        {
            return await _context.Anuncios
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Anuncio> CrearAsync(Anuncio anuncio)
        {
            anuncio.FechaCreacion = DateTime.UtcNow;
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();
            return anuncio;
        }

        public async Task<bool> ActualizarAsync(int id, Anuncio anuncio)
        {
            var existente = await _context.Anuncios.FindAsync(id);
            if (existente == null) return false;

            existente.Titulo = anuncio.Titulo;
            existente.Contenido = anuncio.Contenido;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null) return false;

            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
