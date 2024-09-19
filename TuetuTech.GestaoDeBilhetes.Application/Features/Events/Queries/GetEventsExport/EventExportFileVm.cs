namespace TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportFileVm
    {
        public string EventExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Date { get; set; }
    }
}