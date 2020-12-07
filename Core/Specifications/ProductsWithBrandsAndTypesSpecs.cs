using System;
using System.Linq.Expressions;
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

        public ProductsWithBrandsAndTypesSpecs(int id) : base(x =>x.Id == id)
        {
            AddIncluds(x => x.ProductBrand);
            AddIncluds(x => x.ProductType);
        }
    }
}