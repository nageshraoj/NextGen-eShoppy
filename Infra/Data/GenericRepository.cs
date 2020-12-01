using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly StoreContext _Product;

        public GenericRepository(StoreContext product)
        {
            _Product = product;
        }


        public async Task<IReadOnlyList<T>> GetAllByAsync()
        {
            return await _Product.Set<T>().ToListAsync();
        }

        public async Task<T> GetIdByAsync(int id)
        {
            return await _Product.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetSpecificationsAsyn(ISpecifications<T> spec)
        {
            return await getSpefication(spec).ToListAsync();
        }

        public async Task<T> GetSpecificationsByIDAsync(ISpecifications<T> spec)
        {
            return await getSpefication(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> getSpefication(ISpecifications<T> spec)
        {
            return SpecificationElvauator<T>.GetQuerable(_Product.Set<T>().AsQueryable(), spec);
        }
    }
}