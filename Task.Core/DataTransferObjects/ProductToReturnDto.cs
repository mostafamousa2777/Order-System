using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;

namespace Taskk.Core.DataTransferObjects
{
    public class ProductToReturnDto
    {
      //  public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
       // public ICollection<OrderItem> OrderItems { get; set; }

    }
}
