using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public UpdateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MinimumLength(50).WithMessage("{PropertyName} deve conter menos de 50 caracteres.");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(DateTime.Now);
            RuleFor(x => x)
                .MustAsync(NameEventoEDataUnico)
                .WithMessage("Um evento com o mesmo nome e data já existe.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .GreaterThan(0);

        }
        private async Task<bool> NameEventoEDataUnico(UpdateEventCommand command, CancellationToken token)
        {
            return !await _eventRepository.IsEventNameAndDateUnique(command.Name, command.Date);
        }
    }
}
