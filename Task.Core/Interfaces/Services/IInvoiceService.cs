using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;

namespace Taskk.Core.Interfaces.Services
{
    public interface IInvoiceService
    {
       
        Task<IEnumerable<InvoiceToReturnDto>> GetAllInvoicesAsync();
        Task<InvoiceToReturnDto> GetInvoiceAsync(int id);
    }
}
