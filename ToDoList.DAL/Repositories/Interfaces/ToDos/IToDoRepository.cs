using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.DAL.Repositories.Interfaces.ToDos;

public interface IToDoRepository<TEntity> : IRepositoryBase<TEntity>
where TEntity : BaseEntity
{
    
}