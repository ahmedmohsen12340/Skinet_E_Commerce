using System.Linq.Expressions;
using Core.Specifications;

namespace Core;

public interface IGenericRepo<T> where T : BaseEntity
{
    // Task<T> GetByIdAsync(int id);
    // Task<IEnumerable<T>> ListAllAsync();
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IEnumerable<T>> ListAllAsync(ISpecification<T> spec);

}
