using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuetuTech.GestaoDeBilhetes.Api.Utility;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Commands.CreatedCategory;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.CreateEvent;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.DeleteEvent;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.UpdateEvent;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventDetail;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsExport;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsList;

namespace TuetuTech.GestaoDeBilhetes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var dtos = await _mediator.Send(new GetEventsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
        {
            var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());

            return File(fileDto.Date!, fileDto.ContentType, fileDto.EventExportFileName);
        }
    }
}
