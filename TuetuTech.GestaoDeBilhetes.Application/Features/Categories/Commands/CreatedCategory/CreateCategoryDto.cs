using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Commands.CreatedCategory
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
