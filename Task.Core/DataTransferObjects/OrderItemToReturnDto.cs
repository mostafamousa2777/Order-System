using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;

namespace Taskk.Core.DataTransferObjects
{
    public class OrderItemToReturnDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }

        public string Order { get; set; }
        public string Product { get; set; }
    }
}
