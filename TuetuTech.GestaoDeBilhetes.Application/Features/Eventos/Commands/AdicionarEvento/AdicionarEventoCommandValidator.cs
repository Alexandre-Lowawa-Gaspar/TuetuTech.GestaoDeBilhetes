using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AdicionarEvento
{
    public class AdicionarEventoCommandValidator : AbstractValidator<AdicionarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        public AdicionarEventoCommandValidator(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} não pode ter mais de 50 caracteres.");
            RuleFor(p => p.Data)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(e => e)
                .MustAsync(NomeEventoEDataUnico)
                .WithMessage("Um evento com o mesmo nome e data já existe.");
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .GreaterThan(0);
        }
        private async Task<bool> NomeEventoEDataUnico(AdicionarEventoCommand e, CancellationToken token)
        {
            return !(await _eventoRepository.IsNomeEventoEDataUnico(e.Nome, e.Data));
        }
    }
}
