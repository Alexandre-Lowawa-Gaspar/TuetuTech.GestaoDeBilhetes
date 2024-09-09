using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasList
{
    public class ObterCategoriasListQueryHandler : IRequestHandler<ObterCategoriasListQuery, List<CategoriaListVm>>
    {
        private readonly IAsyncRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapper;

        public ObterCategoriasListQueryHandler(IAsyncRepository<Categoria> categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaListVm>> Handle(ObterCategoriasListQuery request, CancellationToken cancellationToken)
        {
            var categorias = (await _categoriaRepository.ObterTodosAsync()).OrderBy(x => x.Nome);
            return _mapper.Map<List<CategoriaListVm>>(categorias);
        }
    }
}
