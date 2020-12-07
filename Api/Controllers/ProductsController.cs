using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;
using Core.Specifications;
using Api.Dtos;
using AutoMapper;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _Product;
        private readonly IGenericRepository<ProductBrand> _ProductBrand;
        private readonly IGenericRepository<ProductType> _ProductType;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> product,
                        IGenericRepository<ProductBrand> productBrand,
                        IGenericRepository<ProductType> productType,
                        IMapper mapper)
        {
            _Product = product;
            _ProductBrand = productBrand;
            _ProductType = productType;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<List<ProductsToDisplayDto>>>> getProducts()
        {
            var spec = new ProductsWithBrandsAndTypesSpecs();
            var products = await _Product.GetSpecificationsAsyn(spec);
            var produtsDTO = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToDisplayDto>>(products);
            return Ok(produtsDTO);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProductsToDisplayDto>> getProduct(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecs(id);
            var product = await _Product.GetSpecificationsByIDAsync(spec);
            return Ok(_mapper.Map<Product, ProductsToDisplayDto>(product));
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