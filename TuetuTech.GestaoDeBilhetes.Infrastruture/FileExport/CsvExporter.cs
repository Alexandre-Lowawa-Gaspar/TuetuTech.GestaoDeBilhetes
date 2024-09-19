using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsExport;

namespace TuetuTech.GestaoDeBilhetes.Infrastruture.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventoExportadoDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(eventoExportadoDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
