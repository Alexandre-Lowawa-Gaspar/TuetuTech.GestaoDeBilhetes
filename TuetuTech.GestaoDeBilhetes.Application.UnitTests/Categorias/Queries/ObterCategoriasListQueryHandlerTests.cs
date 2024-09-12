using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasList;
using TuetuTech.GestaoDeBilhetes.Application.Profiles;
using TuetuTech.GestaoDeBilhetes.Application.UnitTests.Mocks;

namespace TuetuTech.GestaoDeBilhetes.Application.UnitTests.Categorias.Queries
{
    public class ObterCategoriasListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoriaRepository> _mockCategoriaRepository;
        public ObterCategoriasListQueryHandlerTests()
        {
            _mockCategoriaRepository = RepositoryMocks.ObterCategoriaRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task ObterCategoriasTest()
        {
            var handler = new ObterCategoriasListQueryHandler(_mockCategoriaRepository.Object, _mapper);
            var resultado = await handler.Handle(new ObterCategoriasListQuery(),CancellationToken.None);
            resultado.ShouldBeOfType<List<CategoriaListVm>>();
        }
    }
}
