using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Features.Orders.Queries.ObterOrdersPorMes
{
    public class OrdersForMonthDto
    {
        public Guid Id { get; set; }
        public int OrderOrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
