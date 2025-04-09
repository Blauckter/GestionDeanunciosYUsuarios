using Application.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Usuarios = new UsuarioRepository(_context);
            Roles = new RolRepository(_context);
            Anuncios = new AnuncioRepository(_context);
        }

        public IUsuarioRepository Usuarios { get; }
        public IRolRepository Roles { get; }
        public IAnuncioRepository Anuncios { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
