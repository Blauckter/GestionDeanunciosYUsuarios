using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly AppDbContext _context;
        public AnuncioRepository(AppDbContext context) => _context = context;

        public async Task<Anuncio> AddAsync(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();
            return anuncio;
        }

        public async Task<IEnumerable<Anuncio>> GetAllAsync() =>
            await _context.Anuncios.Include(a => a.Usuario).ToListAsync();

        public async Task<Anuncio?> GetByIdAsync(int id) =>
            await _context.Anuncios.Include(a => a.Usuario).FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Anuncio>> GetByUsuarioIdAsync(int usuarioId) =>
            await _context.Anuncios.Where(a => a.UsuarioId == usuarioId).ToListAsync();

        public async Task<Anuncio> UpdateAsync(Anuncio anuncio)
        {
            _context.Anuncios.Update(anuncio);
            await _context.SaveChangesAsync();
            return anuncio;
        }
    }
}
