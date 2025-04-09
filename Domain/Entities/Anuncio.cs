namespace Domain.Entities
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public bool UsuarioEliminado { get; set; } = false;
    }
}
