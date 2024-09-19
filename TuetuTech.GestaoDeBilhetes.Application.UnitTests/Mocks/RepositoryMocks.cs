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
        public static Mock<ICategoryRepository> ObterCategoriaRepository()
        {
            var concertoGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var showGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenciaGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categorias = new List<Domain.Entities.Category>
            {
                new Domain.Entities.Category
                {
                    CategoryId = concertoGuid,
                    Name = "Concerts"
                },
                new Domain.Entities.Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicais"
                },
                new Domain.Entities.Category
                {
                    CategoryId = conferenciaGuid,
                    Name = "Conferencias"
                },
                 new Domain.Entities.Category
                {
                    CategoryId = showGuid,
                    Name = "Shows"
                }
            };

            var mockCategoriaRepository = new Mock<ICategoryRepository>();
            mockCategoriaRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categorias);

            mockCategoriaRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Category>())).ReturnsAsync(
                (Domain.Entities.Category category) =>
                {
                    categorias.Add(category);
                    return category;
                });

            return mockCategoriaRepository;
        }

    }
}
