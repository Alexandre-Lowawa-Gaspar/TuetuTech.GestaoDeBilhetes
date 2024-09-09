using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria
{
    public class AdicionarCategoriaCommandValidator : AbstractValidator<AdicionarCategoriaCommand>
    {
        public AdicionarCategoriaCommandValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} não pode ter mais de 50 caracteres.");
        }
    }
}
