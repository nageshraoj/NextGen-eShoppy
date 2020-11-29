using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.Extensions.Logging;

namespace Infra.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loger)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var proddata = File.ReadAllText("../Infra/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(proddata);
                    foreach (var prod in brands)
                    {
                        context.ProductBrands.Add(prod);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typedata = File.ReadAllText("../Infra/Data/SeedData/types.json");
                    var prodtypes = JsonSerializer.Deserialize<List<ProductType>>(typedata);
                    foreach (var prod in prodtypes)
                    {
                        context.ProductTypes.Add(prod);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var proddata = File.ReadAllText("../Infra/Data/SeedData/products.json");
                    var brands = JsonSerializer.Deserialize<List<Product>>(proddata);
                    foreach (var prod in brands)
                    {
                        context.Products.Add(prod);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loger.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}