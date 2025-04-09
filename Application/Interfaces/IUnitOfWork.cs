namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUsuarioRepository Usuarios { get; }
        IRolRepository Roles { get; }
        IAnuncioRepository Anuncios { get; }
        Task<int> SaveChangesAsync();
    }
}
