using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasListComEventos
{
    public class CategoriaEventosListVm
    {
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<CategoriaEventoDto>? Eventos { get; set; }

    }
}
