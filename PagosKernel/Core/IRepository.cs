namespace PagosKernel.Core;

public interface IRepository<T, in TId> where T : AggregateRoot
{
    Task<T?> FindByIdAsync(TId id);

    Task CreateAsync(T obj);
    
}
