using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces.Repos;
using Taskk.Core.Interfaces.Services;
using Taskk.Repository.Specifications;

namespace Taskk.Services
{
    public class CustomerService : ICustomerService
        
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
          _mapper = mapper;
        }

       

        public async Task<IEnumerable<CustomerToReturnDto>> GetAllCustomerAsync(CustomerSpecificationParameter parameter)
        {
            var specs = new CustomerSpecification(parameter);
            var customer = await _unitOfWork.Repository<Customer, int>().GetAllWithSpecsAsync(specs);
            return _mapper.Map<IEnumerable<CustomerToReturnDto>>(customer);
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllCustomerOrderAsync()
        {
            var Order=await _unitOfWork.Repository<Order,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<OrderToReturnDto>>(Order);
        }

        public async Task<CustomerToReturnDto> GetCustomerAsync(int id)
        {
            var customer = await _unitOfWork.Repository<Customer, int>().GetAsync(id);
            return _mapper.Map<CustomerToReturnDto>(customer);
        }
        public async Task AddAsync(CustomerToReturnDto customerdto)
        {
            var newcustomer=_mapper.Map<Customer>(customerdto);
         await  _unitOfWork.Repository<Customer,int>().AddAsync(newcustomer);
          await  _unitOfWork.CompeletAsync();
        }
    }
}
