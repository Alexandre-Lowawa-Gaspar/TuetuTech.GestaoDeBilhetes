using MediatR;
using Microsoft.AspNetCore.Mvc;
using TuetuTech.GestaoDeBilhetes.Application.Features.Pedidos.Queries.ObterPedidosPorMeses;

namespace TuetuTech.GestaoDeBilhetes.Api.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/ObterPaginacaoPedidosPorMes", Name = "ObterPaginacaoPedidosPorMes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PaginacaoPedidosPorMesVm>> ObterPaginacaoPedidosPorMes(DateTime data, int pagina, int tamanho)
        {
            var obterPaginacaoPedidosPorMes = new ObterPedidosPorMesQuery() { Data = data, Pagina = pagina, Tamanho = tamanho };
            var dtos = await _mediator.Send(obterPaginacaoPedidosPorMes);
            return Ok(dtos);
        }
    }
}
