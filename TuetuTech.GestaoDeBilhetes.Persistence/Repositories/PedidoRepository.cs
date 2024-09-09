using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Persistence.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(TuetuTechDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Pedido>> ObterPedidosPorMes(DateTime dataPedido, int pagina, int tamanho)
        {
            return await _dbContext.Pedidos.Where(x => x.Data.Month == dataPedido.Month && x.Data.Year == dataPedido.Year)
                .Skip((pagina - 1) * tamanho).Take(tamanho).AsNoTracking().ToListAsync();
        }

        public async Task<int> ObterSomaTotalDePedidosPorMes(DateTime dataPedido)
        {
            return await _dbContext.Pedidos.CountAsync(x => x.Data.Month == dataPedido.Month && x.Data.Year == dataPedido.Year);
        }
    }
}
