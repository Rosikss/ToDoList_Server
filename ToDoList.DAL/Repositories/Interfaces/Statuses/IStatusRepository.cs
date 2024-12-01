using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.DAL.Repositories.Interfaces.Statuses;

public interface IStatusRepository<TEntity>  : IRepositoryBase<TEntity>
where TEntity : BaseEntity
{
    
}