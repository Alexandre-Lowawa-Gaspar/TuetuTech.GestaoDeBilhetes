using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosExportado;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture
{
    public interface ICsvExportar
    {
        byte[] ExportarEventosParaCsv(List<EventoExportadoDto> eventoExportadoDtos);
    }
}
