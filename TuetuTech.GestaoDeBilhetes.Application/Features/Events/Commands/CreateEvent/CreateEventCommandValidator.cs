using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} não pode ter mais de 50 caracteres.");
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(e => e)
                .MustAsync(NameEventoEDataUnico)
                .WithMessage("Um evento com o mesmo nome e data já existe.");
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .GreaterThan(0);
        }
        private async Task<bool> NameEventoEDataUnico(CreateEventCommand e, CancellationToken token)
        {
            return !await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date);
        }
    }
}
