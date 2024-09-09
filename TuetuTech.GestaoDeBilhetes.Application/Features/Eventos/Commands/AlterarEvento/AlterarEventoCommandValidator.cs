using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AlterarEvento
{
    public class AlterarEventoCommandValidator : AbstractValidator<AlterarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        public AlterarEventoCommandValidator(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MinimumLength(50).WithMessage("{PropertyName} deve conter menos de 50 caracteres.");
            RuleFor(x => x.Data)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(DateTime.Now);
            RuleFor(x => x)
                .MustAsync(NomeEventoEDataUnico)
                .WithMessage("Um evento com o mesmo nome e data já existe.");
            RuleFor(x => x.Preco)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .GreaterThan(0);

        }
        private async Task<bool> NomeEventoEDataUnico(AlterarEventoCommand command, CancellationToken token)
        {
            return !await _eventoRepository.IsNomeEventoEDataUnico(command.Nome, command.Data);
        }
    }
}
