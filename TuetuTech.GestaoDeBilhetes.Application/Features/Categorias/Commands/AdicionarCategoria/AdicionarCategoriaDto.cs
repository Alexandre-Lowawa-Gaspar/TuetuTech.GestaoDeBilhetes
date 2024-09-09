using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria
{
    public class AdicionarCategoriaDto
    {
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
