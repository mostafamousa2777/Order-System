using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces.Repos;
using Taskk.Core.Interfaces.Services;
using Taskk.Repository.Repos;

namespace Taskk.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InvoiceToReturnDto>> GetAllInvoicesAsync()
        {
          var inovice=await _unitOfWork.Repository<Invoice,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceToReturnDto>>(inovice);    
        }

        public async Task<InvoiceToReturnDto> GetInvoiceAsync(int id)
        {
            var inovice = await _unitOfWork.Repository<Invoice, int>().GetAsync(id);
            return _mapper.Map<InvoiceToReturnDto>(inovice);
        }
    }
}
