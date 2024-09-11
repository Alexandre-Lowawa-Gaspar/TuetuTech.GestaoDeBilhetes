using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Common;

namespace TuetuTech.GestaoDeBilhetes.Domain.Entities
{
    public class Categoria : InformacaoGeral
    {
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Evento>? Eventos { get; set; }

    }
}
