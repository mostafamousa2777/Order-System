using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces;

namespace Taskk.Repository.Specifications
{
    public class SpecificationEvaluator<TEntity,Tkey>where TEntity : BastEntity<Tkey>
    {
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> Inputquery,ISpecifications<TEntity> specifications) 
        
        {
            var query=Inputquery;
            if(specifications.Criteria != null) {
            query=query.Where(specifications.Criteria);
               
            
            }
            return query;
        }
    }
}
