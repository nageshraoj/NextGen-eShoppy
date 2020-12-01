using System.Linq;
using Core.Entity;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class SpecificationElvauator<TEntity> where TEntity:BaseEntity
    {

        public static IQueryable<TEntity> GetQuerable(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria !=null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
        
    }
}