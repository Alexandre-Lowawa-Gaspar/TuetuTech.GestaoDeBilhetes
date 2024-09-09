using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AlterarEvento
{
    public class AlterarEventoCommandHandler : IRequestHandler<AlterarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public AlterarEventoCommandHandler(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AlterarEventoCommand request, CancellationToken cancellationToken)
        {
            var eventoParaAlterar = await _eventoRepository.ObterPorIdAsync(request.EventoId);
            var validacao = new AlterarEventoCommandValidator(_eventoRepository);
            var resultadoValidacao = await validacao.ValidateAsync(request);
            if (resultadoValidacao.Errors.Count > 0)
                throw new Exceptions.ValidationException(resultadoValidacao);

            _mapper.Map(request, eventoParaAlterar, typeof(AlterarEventoCommand), typeof(Evento));
            await _eventoRepository.AlterarAsync(eventoParaAlterar);
            return Unit.Value;
        }
    }
}
