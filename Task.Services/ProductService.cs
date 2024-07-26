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
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task AddAsync(ProductToReturnDto ProductDto)
        {
            var newProduct = _mapper.Map<Product>(ProductDto);
            await _unitOfWork.Repository<Product, int>().AddAsync(newProduct);
            await _unitOfWork.CompeletAsync();
        }

        public async Task<IEnumerable<ProductToReturnDto>> GetAllProductAsync() { 
        var product=await _unitOfWork.Repository<Product,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductToReturnDto>>(product);
        
        }
        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product, int>().GetAsync( id);
            return _mapper.Map<ProductToReturnDto>(product);

        }

    }
}
