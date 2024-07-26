using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;

namespace Taskk.Core.Interfaces.Services
{
    public interface IProductService
    {
        /*
           
            o POST /api/products - Add a new product (admin only)
            o PUT /api/products/{productId} - Update product details (admin only)
         
         */

        Task<IEnumerable<ProductToReturnDto>> GetAllProductAsync();
        Task<ProductToReturnDto> GetProductAsync(int id);
        Task AddAsync(ProductToReturnDto ProductDto);

    }
}
