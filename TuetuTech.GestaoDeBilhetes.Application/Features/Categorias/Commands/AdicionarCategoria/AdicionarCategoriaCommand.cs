using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria
{
    public class AdicionarCategoriaCommand : IRequest<AdicionarCategoriaCommandResponse>
    {
        public string Nome { get; set; } = string.Empty;
    }
}
