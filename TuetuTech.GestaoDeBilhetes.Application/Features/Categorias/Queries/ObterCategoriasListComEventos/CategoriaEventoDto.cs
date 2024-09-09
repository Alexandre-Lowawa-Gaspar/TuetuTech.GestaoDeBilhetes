namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasListComEventos
{
    public class CategoriaEventoDto
    {
        public Guid EventoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Preco { get; set; }
        public string? Artista { get; set; }
        public DateTime Data { get; set; }
        public Guid CategoriaId { get; set; }
    }
}