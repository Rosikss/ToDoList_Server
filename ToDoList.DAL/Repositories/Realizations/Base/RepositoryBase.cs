using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.DAL.Repositories.Realizations.Base;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }

    public TEntity Update(TEntity entity)
    {
        return _dbSet.Update(entity).Entity;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = default, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
    {
        var query = _dbSet.AsNoTracking();

        if (include is not null)
        {
            query = include(query);
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? predicate = default, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
    {
        var query = _dbSet.AsNoTracking();

        if (include is not null)
        {
            query = include(query);
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}