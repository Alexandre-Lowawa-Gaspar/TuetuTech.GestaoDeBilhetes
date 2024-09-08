using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Events
{
    public class EventoDetailVm
    {
        public Guid EventoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Preco { get; set; }
        public string? Artista { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; } = default!;
    }
}
