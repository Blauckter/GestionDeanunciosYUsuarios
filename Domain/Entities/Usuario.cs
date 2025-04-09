namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;
        public ICollection<Anuncio>? Anuncios { get; set; }
        public ICollection<AsignacionRol>? Asignaciones { get; set; }
    }
}
