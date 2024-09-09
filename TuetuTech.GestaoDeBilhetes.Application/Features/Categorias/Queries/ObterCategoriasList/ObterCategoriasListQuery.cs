using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasList
{
    public class ObterCategoriasListQuery : IRequest<List<CategoriaListVm>>
    {
    }
}
