using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<Rol> AddAsync(Rol rol);
        Task<Rol> UpdateAsync(Rol rol);
        Task DeleteAsync(int id); 
    }
}
