using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasListComEventos
{
    public class ObterCategoriasListComEventosQuery : IRequest<List<CategoriaEventosListVm>>
    {
        public bool IncluirHistorico { get; set; }
    }
}
