using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosList
{
    public class EventoListVm
    {
        public Guid EventoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
