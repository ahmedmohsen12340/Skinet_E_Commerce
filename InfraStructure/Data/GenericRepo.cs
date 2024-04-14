using Core;
using InfraStucture.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure;

public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
{
    private readonly StoreDbContext _DbContext;
    public GenericRepo(StoreDbContext storeDbContext)
    {
        _DbContext = storeDbContext;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _DbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _DbContext.Set<T>().ToListAsync();
    }
}
