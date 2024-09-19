using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsExport;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
