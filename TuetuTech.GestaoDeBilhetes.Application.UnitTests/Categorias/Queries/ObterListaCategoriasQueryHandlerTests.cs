using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Queries.GetCategoriesList;
using TuetuTech.GestaoDeBilhetes.Application.Profiles;
using TuetuTech.GestaoDeBilhetes.Application.UnitTests.Mocks;

namespace TuetuTech.GestaoDeBilhetes.Application.UnitTests.Categorias.Queries
{
    public class ObterListaCategoriasQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoriaRepository;
        public ObterListaCategoriasQueryHandlerTests()
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
            var handler = new GetCategoryListQueryHandler(_mockCategoriaRepository.Object, _mapper);
            var resultado = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
            resultado.ShouldBeOfType<List<CategoryListVm>>();
        }
    }
}
