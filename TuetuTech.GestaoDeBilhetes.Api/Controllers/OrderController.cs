using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuetuTech.GestaoDeBilhetes.Application.Features.Orders.Queries.ObterOrdersPorMes;

namespace TuetuTech.GestaoDeBilhetes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/ObterPaginacaoOrdersPorMes", Name = "ObterPaginacaoOrdersPorMes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(dtos);
        }
    }
}
