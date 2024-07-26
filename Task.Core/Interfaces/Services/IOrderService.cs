using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;

namespace Taskk.Core.Interfaces.Services
{
    public interface IOrderService
    {

        /*     Order Endpoints:
         o POST /api/orders - Create a new order
          
         status - Update order status(admin only)*/
        Task<IEnumerable<OrderToReturnDto>> GetAllOrderAsync();
        Task<OrderToReturnDto> GetOrderAsync(int id);
        Task AddAsync(OrderToReturnDto orderdto);


    }
}
