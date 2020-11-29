using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _Product;

        public ProductsController(IProductRepository product)
        {
            _Product = product;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<List<Product>>>> getProducts()
        {
            var products = await _Product.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<string>> getProduct(int id)
        {
            var product = await _Product.GetProductByIdAsync(id);

            return Ok(product);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getBrands()
        {
            return Ok(await _Product.GetProductBrandsAsync());
        }

        [HttpGet("brands/{id}")]

        public async Task<ActionResult<ProductBrand>> getBrandsByID(int id)
        {
            return Ok(await _Product.GetProductBrandByIdAsyn(id));
        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> getTypes()
        {
            return Ok(await _Product.GetProductTypesAsync());
        }

        [HttpGet("types/{id}")]

        public async Task<ActionResult<ProductType>> getTypesById(int id)
        {
            return Ok(await _Product.GetProductTypeByIdAsync(id));
        }
    }
}