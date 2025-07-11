using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.Models;

namespace QuizApi.Infrastructure.Database.Postgres.Repository;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _dbContext.AddAsync(entity, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _dbContext.Update(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity[] entities, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entities);
        foreach (var entity in entities)
        {
            _dbContext.RemoveRange(entity);
        }
        await SaveChangesAsync(cancellationToken);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return _dbSet.AsQueryable<TEntity>();;
    }
    
    private async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await  _dbContext.SaveChangesAsync(cancellationToken);
    }
}