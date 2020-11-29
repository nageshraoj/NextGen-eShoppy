using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<ProductBrand> GetProductBrandByIdAsyn(int id);

        Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}