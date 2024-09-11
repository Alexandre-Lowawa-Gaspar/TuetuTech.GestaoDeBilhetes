namespace TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosExportado
{
    public class FicheiroEventoExportadoVm
    {
        public string NomeFicheiroEventoExportado { get; set; } = string.Empty;
        public string TipoConteudo { get; set; } = string.Empty;
        public byte[]? Dados { get; set; }
    }
}