using Api.Dtos;
using AutoMapper;
using Core.Entity;
using Microsoft.Extensions.Configuration;

namespace Api.Healper
{
    public class ProducturlResolver : IValueResolver<Product, ProductsToDisplayDto, string>
    {
        private readonly IConfiguration _config;
        public ProducturlResolver(IConfiguration config)
        {
            _config = config;
        }



        public string Resolve(Product source, ProductsToDisplayDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductUrl))
            {
                return _config["apiurl"] + source.ProductUrl;
            }

            return null;
        }
    }
}