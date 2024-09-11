using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasList;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasListComEventos;

namespace TuetuTech.GestaoDeBilhetes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("todas", Name = "ObterTodasCategorias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoriaListVm>>> ObterTodasCategorias()
        {
            var dtos = await _mediator.Send(new ObterCategoriasListQuery());
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("todascomeventos", Name = "ObterCategoriasComEventos")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoriaEventosListVm>>> ObterCategoriasComEventos(bool incluirHistorico)
        {
            ObterCategoriasListComEventosQuery obterCategoriasListComEventosQuery = new ObterCategoriasListComEventosQuery() { IncluirHistorico = incluirHistorico };

            var dtos = await _mediator.Send(obterCategoriasListComEventosQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategoria")]
        public async Task<ActionResult<AdicionarCategoriaCommandResponse>> Adicionar([FromBody] AdicionarCategoriaCommand adicionarCategoriaCommand)
        {
            var response = await _mediator.Send(adicionarCategoriaCommand);
            return Ok(response);
        }
    }
}
