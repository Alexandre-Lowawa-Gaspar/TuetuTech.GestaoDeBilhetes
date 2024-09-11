using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosExportado
{
    public class ObterEventoExportadoQueryHandler : IRequestHandler<ObterEventosExportadoQuery, FicheiroEventoExportadoVm>
    {
        private IMapper _mapper;
        private readonly IAsyncRepository<Evento> _eventoRepository;
        private readonly ICsvExportar _csvExporter;

        public ObterEventoExportadoQueryHandler(IMapper mapper, IAsyncRepository<Evento> eventoRepository, ICsvExportar csvExporter)
        {
            _mapper = mapper;
            _eventoRepository = eventoRepository;
            _csvExporter = csvExporter;
        }

        public async Task<FicheiroEventoExportadoVm> Handle(ObterEventosExportadoQuery request, CancellationToken cancellationToken)
        {
            var todosEventos = _mapper.Map<List<EventoExportadoDto>>((await _eventoRepository.ObterTodosAsync()).OrderBy(x => x.Data));
            var ficheiroDados = _csvExporter.ExportarEventosParaCsv(todosEventos);
            var eventoExportadoDto = new FicheiroEventoExportadoVm() { TipoConteudo = "text/csv", Dados = ficheiroDados, NomeFicheiroEventoExportado = $"{Guid.NewGuid()}.csv" };
            return eventoExportadoDto;
        }
    }
}
