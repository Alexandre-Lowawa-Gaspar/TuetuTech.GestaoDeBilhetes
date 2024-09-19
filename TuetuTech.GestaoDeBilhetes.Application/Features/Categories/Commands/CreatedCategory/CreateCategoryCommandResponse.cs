using TuetuTech.GestaoDeBilhetes.Application.Response;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Commands.CreatedCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {

        }
        public CreateCategoryDto CategoryDto { get; set; } = default!;
    }
}