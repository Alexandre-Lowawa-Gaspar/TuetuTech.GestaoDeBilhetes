using EmptyFiles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICategoriaRepository> ObterCategoriaRepository()
        {
            var concertoGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var showGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenciaGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    CategoriaId = concertoGuid,
                    Nome = "Concerts"
                },
                new Categoria
                {
                    CategoriaId = musicalGuid,
                    Nome = "Musicais"
                },
                new Categoria
                {
                    CategoriaId = conferenciaGuid,
                    Nome = "Conferencias"
                },
                 new Categoria
                {
                    CategoriaId = showGuid,
                    Nome = "Shows"
                }
            };

            var mockCategoriaRepository = new Mock<ICategoriaRepository>();
            mockCategoriaRepository.Setup(repo => repo.ObterTodosAsync()).ReturnsAsync(categorias);

            mockCategoriaRepository.Setup(repo => repo.AdicionarAsync(It.IsAny<Categoria>())).ReturnsAsync(
                (Categoria category) =>
                {
                    categorias.Add(category);
                    return category;
                });

            return mockCategoriaRepository;
        }

    }
}
