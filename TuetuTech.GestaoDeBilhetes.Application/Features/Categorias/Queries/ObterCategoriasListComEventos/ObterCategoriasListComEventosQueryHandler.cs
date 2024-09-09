using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasListComEventos
{
    public class ObterCategoriasListComEventosQueryHandler : IRequestHandler<ObterCategoriasListComEventosQuery, List<CategoriaEventosListVm>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public ObterCategoriasListComEventosQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaEventosListVm>> Handle(ObterCategoriasListComEventosQuery request, CancellationToken cancellationToken)
        {
            var categorias = (await _categoriaRepository.ObterTodasComEventosAsync(request.IncluirHistorico)).OrderBy(x => x.Nome);
            return _mapper.Map<List<CategoriaEventosListVm>>(categorias);
        }
    }
}
