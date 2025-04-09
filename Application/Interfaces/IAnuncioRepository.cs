using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAnuncioRepository
    {
        Task<IEnumerable<Anuncio>> GetAllAsync();
        Task<Anuncio?> GetByIdAsync(int id);
        Task<Anuncio> AddAsync(Anuncio anuncio);
        Task<Anuncio> UpdateAsync(Anuncio anuncio);
        Task<IEnumerable<Anuncio>> GetByUsuarioIdAsync(int usuarioId);
    }
}
