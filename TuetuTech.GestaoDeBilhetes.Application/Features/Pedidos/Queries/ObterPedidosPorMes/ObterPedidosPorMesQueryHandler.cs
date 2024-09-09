using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Application.Features.Pedidos.Queries.ObterPedidosPorMeses;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Pedidos.Queries.ObterPedidosPorMes
{
    public class ObterPedidosPorMesQueryHandler : IRequestHandler<ObterPedidosPorMesQuery,PaginacaoPedidosPorMesVm>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public ObterPedidosPorMesQueryHandler(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<PaginacaoPedidosPorMesVm> Handle(ObterPedidosPorMesQuery request, CancellationToken cancellationToken)
        {
            var lista = await _pedidoRepository.ObterPedidosPorMes(request.Data, request.Pagina, request.Tamanho);
            var pedidos = _mapper.Map<List<PedidosPorMesDto>>(lista);

            var soma = await _pedidoRepository.ObterSomaTotalDePedidosPorMes(request.Data);
            return new PaginacaoPedidosPorMesVm() { Soma = soma, PedidosPorMeses = pedidos, Pagina = request.Pagina, Tamanho = request.Tamanho };
        }
    }
}
