using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;

namespace Taskk.Core.Interfaces.Repos
{
    public interface IGenericRepo<TEntity,Tkey> where TEntity : BastEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecifications<TEntity> specifications);

        Task<TEntity> GetAsync(Tkey Id);

        Task AddAsync(TEntity entity);  
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
