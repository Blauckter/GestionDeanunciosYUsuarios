using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario> CrearAsync(Usuario usuario);
        Task<bool> ActualizarAsync(int id, Usuario usuario);
        Task<bool> EliminarAsync(int id);
    }
}
