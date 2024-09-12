using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Persistence.IntegrationTests
{
    public class TuetuTechDbContextTests
    {
        private readonly TuetuTechDbContext _tuetuTechDbContext;
        private readonly Mock<ILoggedInUserService> _LoggedInUserServiceMock;
        private readonly string _loggedInUserId;
        public TuetuTechDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TuetuTechDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _LoggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _LoggedInUserServiceMock.Setup(m => m.UtilizadorId).Returns(_loggedInUserId);
            _tuetuTechDbContext = new TuetuTechDbContext(dbContextOptions, _LoggedInUserServiceMock.Object);
        }
        [Fact]
        public async void Save_SetPropriedadeCriadoPor()
        {
            var ev = new Evento() { EventoId = Guid.NewGuid(), Nome = "Evento teste" };
            _tuetuTechDbContext.Eventos.Add(ev);
            await _tuetuTechDbContext.SaveChangesAsync();
            ev.CriadoPor.ShouldBe(_loggedInUserId);
        }
    }
}
