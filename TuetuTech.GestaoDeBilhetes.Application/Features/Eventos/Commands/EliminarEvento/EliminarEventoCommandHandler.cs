using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.EliminarEvento
{
    public class EliminarEventoCommandHandler : IRequestHandler<EliminarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EliminarEventoCommandHandler(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EliminarEventoCommand request, CancellationToken cancellationToken)
        {
            var eventoParaEliminar = await _eventoRepository.ObterPorIdAsync(request.EventoId);
            await _eventoRepository.EliminarAsync(eventoParaEliminar);
            return Unit.Value;
        }
    }
}
