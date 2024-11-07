using Microsoft.EntityFrameworkCore;
using SmartSurprise.Data.Repositories.Contracts;
using System.Linq.Expressions;

namespace SmartSurprise.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext context;
    private readonly DbSet<T> dbSet;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await this.dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await this.dbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await this.dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await this.dbSet.AddAsync(entity, cancellationToken);
    }

    public virtual void Update(T entity)
    {
        this.dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        this.dbSet.Remove(entity);
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await this.context.SaveChangesAsync(cancellationToken);
    }
}