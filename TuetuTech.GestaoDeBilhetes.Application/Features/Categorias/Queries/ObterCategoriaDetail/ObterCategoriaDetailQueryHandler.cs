using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriaDetail
{
    public class ObterCategoriaDetailQueryHandler : IRequestHandler<ObterCategoriaDetailQuery, CategoriaDetailVm>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public ObterCategoriaDetailQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDetailVm> Handle(ObterCategoriaDetailQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(request.Id);
            return _mapper.Map<CategoriaDetailVm>(categoria);
        }
    }
}
