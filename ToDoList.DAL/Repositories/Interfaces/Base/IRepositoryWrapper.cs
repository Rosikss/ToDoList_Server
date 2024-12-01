using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Statuses;
using ToDoList.DAL.Repositories.Interfaces.ToDos;

namespace ToDoList.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    public IStatusRepository StatusRepository { get; }
    public IToDoRepository ToDoRepository { get; }
    public Task<int> SaveChangesAsync();
}