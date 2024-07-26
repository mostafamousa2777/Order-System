using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskk.Core.Entites
{
    public class Invoice:BastEntity<int>
    {
        //InvoiceId, OrderId, InvoiceDate, TotalAmount
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalAmount { get; set; }
        public Order Order { get; set; }


    }
}
