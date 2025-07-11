using System.Linq.Expressions;
using QuizApi.Infrastructure.Models;

namespace QuizApi.Infrastructure.Database.Postgres.Repository;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    public Task DeleteAsync(TEntity[] entities, CancellationToken cancellationToken);
    
    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    
    public IQueryable<TEntity> AsQueryable();   
}