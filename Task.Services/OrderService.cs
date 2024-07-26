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

namespace Taskk.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderToReturnDto orderdto)
        {
            var neworder = _mapper.Map<Order>(orderdto);
            await _unitOfWork.Repository<Order, int>().AddAsync(neworder);
            await _unitOfWork.CompeletAsync();
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrderAsync()
        {
           var Order= await _unitOfWork.Repository<Order,int>().GetAllAsync();
            return  _mapper.Map<IEnumerable<OrderToReturnDto>>(Order);
        }

        public async Task<OrderToReturnDto> GetOrderAsync(int id)
        {
            var Order = await _unitOfWork.Repository<Order, int>().GetAsync(id);    
            return _mapper.Map<OrderToReturnDto>(Order);
        }

    }
}
