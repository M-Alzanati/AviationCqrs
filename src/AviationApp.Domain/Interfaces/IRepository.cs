using System.Linq.Expressions;
using AviationApp.Domain.Entities.Base;

namespace AviationApp.Domain.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    Task<IEnumerable<T?>> GetAll(CancellationToken cancellationToken);
    
    Task<T?> GetById(int id, CancellationToken cancellationToken);

    IQueryable<T> Get(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        IEnumerable<string>? includeProperties = null);
    
    Task Insert(T? obj, CancellationToken cancellationToken);
    
    Task Update(T? obj);
    
    Task Delete(int id, CancellationToken cancellationToken);

    Task<bool> Any(CancellationToken cancellationToken);

    Task Save(CancellationToken cancellationToken);
}