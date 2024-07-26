using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;

namespace Taskk.Core.Interfaces.Repos
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IGenericRepo<TEntity,Tkey> Repository<TEntity, Tkey>() where TEntity : BastEntity<Tkey>;
        Task<int> CompeletAsync();
    }
}
