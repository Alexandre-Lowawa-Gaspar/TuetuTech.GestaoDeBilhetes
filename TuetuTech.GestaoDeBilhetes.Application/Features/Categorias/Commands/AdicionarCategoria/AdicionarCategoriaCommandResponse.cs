using TuetuTech.GestaoDeBilhetes.Application.Response;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria
{
    public class AdicionarCategoriaCommandResponse : BaseResponse
    {
        public AdicionarCategoriaCommandResponse() : base()
        {

        }
        public AdicionarCategoriaDto CategoriaDto { get; set; } = default!;
    }
}