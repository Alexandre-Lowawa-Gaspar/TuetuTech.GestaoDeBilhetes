using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuetuTech.GestaoDeBilhetes.Api.Utility;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AlterarEvento;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.EliminarEvento;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventoDetail;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosExportado;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosList;

namespace TuetuTech.GestaoDeBilhetes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : Controller
    {
        private readonly IMediator _mediator;

        public EventoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("todos", Name = "ObterTodosEventos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventoListVm>>> ObterTodosEventos()
        {
            var lista = await _mediator.Send(new ObterTodosEventosListQuery());
            return Ok(lista);
        }
        [HttpGet("{id}", Name = "ObterEventoPorId")]
        public async Task<ActionResult<EventoDetailVm>> ObterEventoPorId(Guid id)
        {
            var obterEventoDetailQuery = new ObterEventoDetailQuery() { Id = id };
            return Ok(await _mediator.Send(obterEventoDetailQuery));
        }
        [HttpPost(Name = "AddEvento")]
        public async Task<ActionResult<Guid>> Adicionar([FromBody] AdicionarCategoriaCommand adicionarEventoCommand)
        {
            var id = await _mediator.Send(adicionarEventoCommand);
            return Ok(id);
        }
        [HttpPut(Name = "AlterarEvento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Alterar([FromBody] AlterarEventoCommand alterarEventoCommand)
        {
            await _mediator.Send(alterarEventoCommand);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "EliminarEvento")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            var eliminarEventoCommand = new EliminarEventoCommand() { EventoId = id };
            await _mediator.Send(eliminarEventoCommand);
            return NoContent();
        }
        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new ObterEventosExportadoQuery());

            return File(fileDto.Dados!, fileDto.TipoConteudo, fileDto.NomeFicheiroEventoExportado);

        }
    }
}
