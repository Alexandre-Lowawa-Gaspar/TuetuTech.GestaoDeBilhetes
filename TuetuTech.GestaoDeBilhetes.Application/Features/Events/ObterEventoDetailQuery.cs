using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Events
{
    public class ObterEventoDetailQuery : IRequest<EventoDetailVm>
    {
        public Guid Id { get; set; }
    }
}
