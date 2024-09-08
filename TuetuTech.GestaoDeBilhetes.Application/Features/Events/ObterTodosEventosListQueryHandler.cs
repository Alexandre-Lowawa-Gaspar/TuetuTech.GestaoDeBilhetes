using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Events
{
    public class ObterTodosEventosListQueryHandler : IRequestHandler<ObterTodosEventosListQuery, List<EventoListVm>>
    {
        private readonly IAsyncRepository<Evento> _eventoRepository;
        private readonly IMapper _mapper;
        public ObterTodosEventosListQueryHandler(IMapper mapper, IAsyncRepository<Evento> eventoRepository)
        {
            _mapper = mapper;
            _eventoRepository = eventoRepository;
        }
        public async Task<List<EventoListVm>> Handle(ObterTodosEventosListQuery request, CancellationToken cancellationToken)
        {
            var todosEventos = (await _eventoRepository.ObterTodosAsync()).OrderBy(x => x.Data);
            return _mapper.Map<List<EventoListVm>>(todosEventos);
        }
    }
}
