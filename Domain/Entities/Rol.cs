namespace Domain.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public ICollection<AsignacionPermiso>? Permisos { get; set; }
        public ICollection<AsignacionRol>? Asignaciones { get; set; }
    }
}
