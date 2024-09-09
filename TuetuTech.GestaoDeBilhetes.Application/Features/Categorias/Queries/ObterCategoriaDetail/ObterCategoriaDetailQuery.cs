using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriaDetail
{
    public class ObterCategoriaDetailQuery : IRequest<CategoriaDetailVm>
    {
        public Guid Id { get; set; }

    }
}
