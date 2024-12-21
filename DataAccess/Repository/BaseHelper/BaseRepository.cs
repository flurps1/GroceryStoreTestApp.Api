using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Repository<TEntity>(AppContext context) : IRepository<TEntity>
    where TEntity : class
{
    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}