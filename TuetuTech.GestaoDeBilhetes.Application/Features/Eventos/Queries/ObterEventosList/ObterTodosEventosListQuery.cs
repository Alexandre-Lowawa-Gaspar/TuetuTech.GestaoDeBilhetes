using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosList
{
    public class ObterTodosEventosListQuery : IRequest<List<EventoListVm>>
    {
    }
}
