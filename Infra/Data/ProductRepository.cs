using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _product;

        public ProductRepository(StoreContext Product)
        {
            _product = Product;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsyn(int id)
        {
            return await _product.ProductBrands.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _product.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _product.Products
              .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _product.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _product.ProductTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _product.ProductTypes.ToListAsync();
        }
    }
}