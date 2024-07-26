using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces.Repos;
using Taskk.Repository.Data;

namespace Taskk.Repository.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Hashtable _repositories;

       public UnitOfWork(DataContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public IGenericRepo<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BastEntity<Tkey>
        {
            var Tybename = typeof(TEntity).Name;
            if(_repositories.ContainsKey(Tybename)) return _repositories[Tybename] as  GenericRepo<TEntity, Tkey>;

            var Repo= new GenericRepo<TEntity, Tkey>(_context);
             _repositories.Add(Tybename, Repo);
            return Repo;
        }
        public async Task<int> CompeletAsync() => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

       
    }
}
