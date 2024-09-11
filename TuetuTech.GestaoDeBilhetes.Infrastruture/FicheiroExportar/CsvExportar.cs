using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosExportado;

namespace TuetuTech.GestaoDeBilhetes.Infrastruture.FicheiroExportar
{
    public class CsvExportar : ICsvExportar
    {
        public byte[] ExportarEventosParaCsv(List<EventoExportadoDto> eventoExportadoDtos)
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
