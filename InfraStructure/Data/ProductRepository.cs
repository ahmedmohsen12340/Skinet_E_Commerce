using Core;
using Core.Entities;
using InfraStucture.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure;

public class ProductRepository : IProductRepository
{
    private readonly StoreDbContext _dbContext;
    public ProductRepository(StoreDbContext storeDbContext)
    {
        _dbContext = storeDbContext;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _dbContext.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).Where(p=>p.Id==id).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _dbContext.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _dbContext.ProductTypes.ToListAsync();
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        return await _dbContext.ProductBrands.ToListAsync();
    }

}
