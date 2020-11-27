using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly StoreContext _ApiData;

        public ProductsController(StoreContext ApiData)
        {
            _ApiData = ApiData;

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<List<Product>>>> getProducts()
        {
            var products = await _ApiData.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<string>> getProduct(int id)
        {
            var product = await _ApiData.Products.FindAsync(id);

            return Ok(product);
        }
    }
}