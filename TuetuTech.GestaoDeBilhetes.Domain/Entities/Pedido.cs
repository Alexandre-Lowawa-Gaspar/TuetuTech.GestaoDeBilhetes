using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Common;

namespace TuetuTech.GestaoDeBilhetes.Domain.Entities
{
    public class Pedido : InformacaoGeral
    {
        public Guid Id { get; set; }
        public Guid UtilizadorId { get; set; }
        public int Total { get; set; }
        public DateTime Data { get; set; }
        public int Pago { get; set; }

    }
}
