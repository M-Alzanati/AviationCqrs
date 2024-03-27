using AviationApp.Domain.Entities.Base;
using AviationApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AviationApp.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly DbContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(DbContext context)
    {
        this._context = context;
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T?>> GetAll(CancellationToken cancellationToken)
    {
        return await _entities.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _entities.FindAsync(id, cancellationToken);
    }

    public async Task Insert(T? obj, CancellationToken cancellationToken)
    {
        if (obj != null)
        {
            await _entities.AddAsync(obj, cancellationToken);
        }
    }

    public Task Update(T? obj)
    {
        _entities.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var existing = await _entities.FindAsync([id], cancellationToken);
        if (existing != null) _entities.Remove(existing);
    }

    public async Task<bool> Any(CancellationToken cancellationToken)
    {
        return await _entities
            .AnyAsync(cancellationToken);
    }
    
    public async Task Save(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}