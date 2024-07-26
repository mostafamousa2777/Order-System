using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskk.Core.Entites
{
    public class Customer: BastEntity<int>
    {
        // CustomerId, Name, Email, ** Orders
        //public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
       



    }
}
