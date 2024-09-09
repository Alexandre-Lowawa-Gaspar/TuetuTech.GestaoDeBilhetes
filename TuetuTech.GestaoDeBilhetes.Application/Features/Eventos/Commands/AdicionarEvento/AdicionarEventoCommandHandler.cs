using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AdicionarEvento
{
    public class AdicionarEventoCommandHandler : IRequestHandler<AdicionarEventoCommand, Guid>
    {
        private readonly IEventoRepository _eventoRepository;
        private IMapper _mapper;

        public AdicionarEventoCommandHandler(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AdicionarEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = _mapper.Map<Evento>(request);

            var validacao = new AdicionarEventoCommandValidator(_eventoRepository);
            var resultadoValidacao = await validacao.ValidateAsync(request);
            if (resultadoValidacao.Errors.Count > 0)
                throw new Exceptions.ValidationException(resultadoValidacao);

            evento = await _eventoRepository.AdicionarAsync(evento);
            
            return evento.EventoId;
        }
    }
}
