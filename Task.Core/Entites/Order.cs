using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskk.Core.Entites
{
    public class Order: BastEntity<int>
    {
        // OrderId, CustomerId, OrderDate, TotalAmount, **OrderItems, 
        // PaymentMethod, Status
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Double TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Invoice Invoice { get; set; }






    }
}
