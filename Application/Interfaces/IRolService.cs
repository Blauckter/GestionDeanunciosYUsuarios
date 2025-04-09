using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> ObtenerTodosAsync();
        Task<Rol?> ObtenerPorIdAsync(int id);
        Task<Rol> CrearAsync(Rol rol);
        Task<bool> ActualizarAsync(int id, Rol rol);
        Task<bool> EliminarAsync(int id);
    }
}
