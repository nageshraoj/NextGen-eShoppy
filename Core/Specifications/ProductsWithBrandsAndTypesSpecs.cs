using Core.Entity;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndTypesSpecs : BaseSpefications<Product>
    {
        public ProductsWithBrandsAndTypesSpecs()
        {
            AddIncluds(x => x.ProductBrand);
            AddIncluds(x => x.ProductType);
        }
    }
}