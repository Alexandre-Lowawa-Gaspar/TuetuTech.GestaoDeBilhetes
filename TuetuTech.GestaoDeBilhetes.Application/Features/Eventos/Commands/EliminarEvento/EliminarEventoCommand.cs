using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.EliminarEvento
{
    public class EliminarEventoCommand : IRequest
    {
        public Guid EventoId { get; set; }

    }
}
