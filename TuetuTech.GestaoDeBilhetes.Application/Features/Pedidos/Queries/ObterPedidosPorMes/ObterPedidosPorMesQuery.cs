using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Pedidos.Queries.ObterPedidosPorMeses
{
    public class ObterPedidosPorMesQuery : IRequest<PaginacaoPedidosPorMesVm>
    {
        public DateTime Data { get; set; }
        public int Pagina { get; set; }
        public int Tamanho { get; set; }
    }
}
