using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<TEntity>
    where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default);

        Task<TEntity?> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default);
    }
}
