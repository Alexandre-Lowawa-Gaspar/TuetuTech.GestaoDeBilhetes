using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Pedidos.Queries.ObterPedidosPorMeses
{
    public class PedidosPorMesDto
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public DateTime Data { get; set; }
    }
}
