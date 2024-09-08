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
    public class ObterEventoDetailQueryHandler : IRequestHandler<ObterEventoDetailQuery, EventoDetailVm>
    {
        private readonly IAsyncRepository<Evento> _eventoRepository;
        private readonly IAsyncRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapper;

        public ObterEventoDetailQueryHandler(IAsyncRepository<Evento> eventoRepository, IAsyncRepository<Categoria> categoriaRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<EventoDetailVm> Handle(ObterEventoDetailQuery request, CancellationToken cancellationToken)
        {
            var @evento = await _eventoRepository.ObterPorIdAsync(request.Id);
            var eventoDetailDto = _mapper.Map<EventoDetailVm>(@evento);
            var categoria = await _categoriaRepository.ObterPorIdAsync(evento.CategoriaId);
            eventoDetailDto.Categoria = _mapper.Map<CategoriaDto>(categoria);
            return eventoDetailDto;
        }
    }
}
