using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAnuncioService
    {
        Task<IEnumerable<Anuncio>> ObtenerTodosAsync();
        Task<Anuncio?> ObtenerPorIdAsync(int id);
        Task<Anuncio> CrearAsync(Anuncio anuncio);
        Task<bool> ActualizarAsync(int id, Anuncio anuncio);
        Task<bool> EliminarAsync(int id);
    }
}
