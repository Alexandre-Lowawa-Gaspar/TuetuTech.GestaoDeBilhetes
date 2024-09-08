using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Domain.Common
{
    public class InformacaoGeral
    {
        public string CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
