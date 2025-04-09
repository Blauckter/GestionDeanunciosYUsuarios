namespace Domain.Entities
{
    public class AsignacionPermiso
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        public int PermisoId { get; set; }
        public Permiso? Permiso { get; set; }
    }
}
