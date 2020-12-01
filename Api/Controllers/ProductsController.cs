using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;
using Core.Specifications;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _Product;
        private readonly IGenericRepository<ProductBrand> _ProductBrand;
        private readonly IGenericRepository<ProductType> _ProductType;

        public ProductsController(IGenericRepository<Product> product,
                        IGenericRepository<ProductBrand> productBrand,
                        IGenericRepository<ProductType> productType)
        {
            _Product = product;
            _ProductBrand = productBrand;
            _ProductType = productType;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<List<Product>>>> getProducts()
        {
            var spec = new ProductsWithBrandsAndTypesSpecs();
            var products = await _Product.GetSpecificationsAsyn(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<string>> getProduct(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecs();
            var product = await _Product.GetSpecificationsByIDAsync(spec);

            return Ok(product);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getBrands()
        {
            return Ok(await _ProductBrand.GetAllByAsync());
        }

        [HttpGet("brands/{id}")]

        public async Task<ActionResult<ProductBrand>> getBrandsByID(int id)
        {
            return Ok(await _ProductBrand.GetIdByAsync(id));
        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> getTypes()
        {
            return Ok(await _ProductType.GetAllByAsync());
        }

        [HttpGet("types/{id}")]

        public async Task<ActionResult<ProductType>> getTypesById(int id)
        {
            return Ok(await _ProductType.GetIdByAsync(id));
        }
    }
}