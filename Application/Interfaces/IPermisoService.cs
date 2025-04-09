using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPermisoService
    {
        Task<IEnumerable<Permiso>> ObtenerTodosAsync();
        Task<Permiso?> ObtenerPorIdAsync(int id);
        Task<Permiso> CrearAsync(Permiso permiso);
        Task<bool> ActualizarAsync(int id, Permiso permiso);
        Task<bool> EliminarAsync(int id);
    }
}
