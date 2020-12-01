using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Specifications;

namespace Core.Interface
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetIdByAsync(int id);
        Task<IReadOnlyList<T>> GetAllByAsync();

        Task<T> GetSpecificationsByIDAsync(ISpecifications<T> spec);

        Task<IReadOnlyList<T>> GetSpecificationsAsyn(ISpecifications<T> spec);
    }
}