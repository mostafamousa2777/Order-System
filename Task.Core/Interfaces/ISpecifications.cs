using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taskk.Core.Interfaces
{
    public interface ISpecifications<T>
    {
        // where
        public Expression<Func<T,bool>> Criteria { get;  }
        //Include
        public List <Expression<Func<T, object>>> IncludeExpression { get;  }

    }
}
