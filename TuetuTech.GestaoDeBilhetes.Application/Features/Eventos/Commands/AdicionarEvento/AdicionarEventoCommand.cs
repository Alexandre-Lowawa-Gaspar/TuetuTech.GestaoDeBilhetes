using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AdicionarEvento
{
    public class AdicionarEventoCommand : IRequest<Guid>
    {
        public Guid EventoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Preco { get; set; }
        public string? Artista { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }
        public Guid CategoriaId { get; set; }
        public override string ToString()
        {
            return $"Nome do evento:{Nome};Preço:{Preco};Por:{Artista};Em:{Data.ToShortDateString()};Descrição:{Descricao};";
        }
    }
}
