using UserService.Domain.Abstractions;

namespace UserService.Infrastructure.Repositories;

internal abstract class Repository<TEntity> where TEntity : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual TEntity Add(TEntity entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var entry = DbContext.Add(entity);
        return entry.Entity;
    }
    
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var entry = await DbContext.AddAsync(entity, cancellationToken);
        return entry.Entity;
    }
    
    public virtual void Delete(TEntity entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        DbContext.Remove(entity);
    }
}

