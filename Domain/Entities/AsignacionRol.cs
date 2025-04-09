namespace Domain.Entities
{
    public class AsignacionRol
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int RolId { get; set; }
        public Rol? Rol { get; set; }
    }
}
