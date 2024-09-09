using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria
{
    public class AdicionarCategoriaCommandHandler : IRequestHandler<AdicionarCategoriaCommand, AdicionarCategoriaCommandResponse>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public AdicionarCategoriaCommandHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<AdicionarCategoriaCommandResponse> Handle(AdicionarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var adicionarCategoriaCommandResponse = new AdicionarCategoriaCommandResponse();

            var validacao = new AdicionarCategoriaCommandValidator();
            var resultadoValidacao = await validacao.ValidateAsync(request);

            if (resultadoValidacao.Errors.Count > 0)
            {
                adicionarCategoriaCommandResponse.Success = false;
                adicionarCategoriaCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in resultadoValidacao.Errors)
                    adicionarCategoriaCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
            if (adicionarCategoriaCommandResponse.Success)
            {
                var categoria = new Categoria() { Nome = request.Nome };
                categoria = await _categoriaRepository.AdicionarAsync(categoria);
                adicionarCategoriaCommandResponse.CategoriaDto = _mapper.Map<AdicionarCategoriaDto>(categoria);
            }
            return adicionarCategoriaCommandResponse;
        }
    }
}
