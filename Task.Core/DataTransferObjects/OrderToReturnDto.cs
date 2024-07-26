using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;

namespace Taskk.Core.DataTransferObjects
{
    public class OrderToReturnDto
    {
       // public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Double TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
       //public string Customer { get; set; }
       // public List<string> OrderItems { get; set; }
       // public String Invoice { get; set; }
    }
}
