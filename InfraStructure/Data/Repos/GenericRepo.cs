using System.Linq.Expressions;
using Core;
using Core.Specifications;
using InfraStructure.Data;
using InfraStucture.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repos;

public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
{
    private readonly StoreDbContext _DbContext;
    public GenericRepo(StoreDbContext storeDbContext)
    {
        _DbContext = storeDbContext;
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> ListAllAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_DbContext.Set<T>().AsQueryable(), spec);
    }

    // public async Task<T> GetByIdAsync(int id)
    // {
    //     return await _DbContext.Set<T>().FindAsync(id);
    // }

    // public async Task<IReadOnlyList<T>> ListAllAsync()
    // {
    //     return await _DbContext.Set<T>().ToListAsync();
    // }


}
