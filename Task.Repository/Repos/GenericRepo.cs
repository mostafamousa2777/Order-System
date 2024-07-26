using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces;
using Taskk.Core.Interfaces.Repos;
using Taskk.Repository.Data;
using Taskk.Repository.Specifications;

namespace Taskk.Repository.Repos
{
    public class GenericRepo<TEntity, Tkey> : IGenericRepo<TEntity, Tkey> where TEntity : BastEntity<Tkey>
    {
        private readonly DataContext _context;

        public GenericRepo(DataContext Context)
        {
            _context = Context;
        }
        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void DeleteAsync(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

      

        public async Task<TEntity> GetAsync(Tkey Id) => await _context.Set<TEntity>().FindAsync(Id);

        public void UpdateAsync(TEntity entity) => _context.Set<TEntity>().Update(entity);


        public async Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecifications<TEntity> specifications) 
            => await SpecificationEvaluator<TEntity, Tkey>.BuildQuery(_context.Set<TEntity>(), specifications).ToListAsync();
    }
}
