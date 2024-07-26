using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskk.Core.Entites
{
    public class Product:BastEntity<int>
    {
        // ProductId, Name, Price, Stock
        public string Name { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
