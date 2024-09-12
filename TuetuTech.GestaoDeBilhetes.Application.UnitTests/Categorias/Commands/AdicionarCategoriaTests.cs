using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria;
using TuetuTech.GestaoDeBilhetes.Application.Profiles;
using TuetuTech.GestaoDeBilhetes.Application.UnitTests.Mocks;
namespace TuetuTech.GestaoDeBilhetes.Application.UnitTests.Categorias.Commands
{
    public class AdicionarCategoriaTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoriaRepository> _mockCategoriaRepository;

        public AdicionarCategoriaTests()
        {
            _mockCategoriaRepository = RepositoryMocks.ObterCategoriaRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_CategoriaValida_AdicionadoCategoriasRepo()
        {
            var handler = new AdicionarCategoriaCommandHandler(_mockCategoriaRepository.Object, _mapper);
            await handler.Handle(new AdicionarCategoriaCommand() { Nome = "Teste" }, CancellationToken.None);
            var todasCategorias = await _mockCategoriaRepository.Object.ObterTodosAsync();
            todasCategorias.Count.ShouldBe(5);
        }

    }
}
