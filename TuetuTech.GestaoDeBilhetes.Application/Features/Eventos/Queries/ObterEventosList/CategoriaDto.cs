using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosList
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
