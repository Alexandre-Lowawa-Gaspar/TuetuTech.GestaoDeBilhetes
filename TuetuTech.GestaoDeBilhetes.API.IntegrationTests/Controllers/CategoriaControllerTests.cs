using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.API.IntegrationTests.Base;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasList;
using TuetuTech.GestaoDeBilhetes.Persistence;

namespace TuetuTech.GestaoDeBilhetes.API.IntegrationTests.Controllers
{
    public class CategoriaControllerTests :
    IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CategoriaControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task RetornaSucessoResult()
        {
            var cliente = _factory.GetAnonymousClient();
            var resposta = await cliente.GetAsync("/api/categoria/todas");
            resposta.EnsureSuccessStatusCode();

            var respostaString = await resposta.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<CategoriaListVm>>(respostaString);

            Assert.IsType<List<CategoriaListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}