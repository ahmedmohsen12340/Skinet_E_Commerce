using System.Text.Json;
using Core;
using Core.Entities;
using InfraStucture.Data;

namespace InfraStructure.Data.SeedData;

public class StoreContextSeed
{
    public static async Task SeedData(StoreDbContext storeDbContext)
    {
        if (!storeDbContext.ProductBrands.Any())
        {
            //E:\Courses\Programming\Programming_projects\Skinet\API\brands.json
            var brandsData = File.ReadAllText("../InfraStructure/Data/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            storeDbContext.ProductBrands.AddRange(brands);
        }
        if (!storeDbContext.ProductTypes.Any())
        {
            
            var typesData = File.ReadAllText("../InfraStructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            storeDbContext.ProductTypes.AddRange(types);
        }
        if (!storeDbContext.Products.Any())
        {
            var productsData = File.ReadAllText("../InfraStructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            storeDbContext.Products.AddRange(products);
        }
        if (storeDbContext.ChangeTracker.HasChanges())
            await storeDbContext.SaveChangesAsync();
    }
}
