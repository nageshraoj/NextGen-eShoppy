using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductRepository _Product;
        public ProductBrandsController(IProductRepository product)
        {
            _Product = product;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<List<ProductBrand>>>> getBrands()
        {
            return Ok(await _Product.GetProductBrandsAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProductBrand>> getBrand(int id)
        {
            return Ok(await _Product.GetProductBrandByIdAsyn(id));
        }
    }
}