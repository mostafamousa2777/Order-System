using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core;
using Taskk.Core.Entites;

namespace Taskk.Repository.Specifications
{
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        // get customers by filtiration
        public CustomerSpecification(CustomerSpecificationParameter specs) :
            base(Customer => Customer.Name.Contains(specs.Name))
        {
            
        }
        // get customer by id
        public CustomerSpecification(int id) : base(Customer=>Customer.Id==id)
        {

        }
    }
}
