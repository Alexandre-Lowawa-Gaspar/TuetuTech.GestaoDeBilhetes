using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence
{
    public interface IPedidoRepository : IAsyncRepository<Pedido>
    {
        Task<List<Pedido>> ObterPedidosPorMes(DateTime dataPedido, int pagina, int tamanho);
        Task<int> ObterSomaTotalDePedidosPorMes(DateTime dataPedido);
    }
}
