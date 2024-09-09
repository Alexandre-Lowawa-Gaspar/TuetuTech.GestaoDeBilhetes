using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Application.Models.Mail;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AdicionarEvento
{
    public class AdicionarEventoCommandHandler : IRequestHandler<AdicionarEventoCommand, Guid>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IEmailService _emailService;
        private IMapper _mapper;

        public AdicionarEventoCommandHandler(IEventoRepository eventoRepository, IMapper mapper, IEmailService emailService)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(AdicionarEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = _mapper.Map<Evento>(request);

            var validacao = new AdicionarEventoCommandValidator(_eventoRepository);
            var resultadoValidacao = await validacao.ValidateAsync(request);
            if (resultadoValidacao.Errors.Count > 0)
                throw new Exceptions.ValidationException(resultadoValidacao);

            evento = await _eventoRepository.AdicionarAsync(evento);
            //Sending email notification to admin address
            var email = new Email() { To = "alexandrelowawagaspar@outlook.com", Body = $"Um novo evento foi criado: {request}", Subject = "Um novo evento foi criado" };

            try
            {
                await _emailService.EnviarEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
            }
            return evento.EventoId;
        }
    }
}
