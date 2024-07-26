using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;

namespace Taskk.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerToReturnDto>> GetAllCustomerAsync(CustomerSpecificationParameter parameter);
        Task<CustomerToReturnDto> GetCustomerAsync(int id);

        Task<IEnumerable<OrderToReturnDto>> GetAllCustomerOrderAsync();

         Task AddAsync(CustomerToReturnDto customerdto);


    }
}
