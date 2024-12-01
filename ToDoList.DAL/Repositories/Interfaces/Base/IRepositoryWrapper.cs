using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Statuses;
using ToDoList.DAL.Repositories.Interfaces.ToDos;

namespace ToDoList.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    public IStatusRepository<Status> StatusRepository { get; }
    public IToDoRepository<ToDo> ToDoRepository { get; }
    public Task<int> SaveChangesAsync();
}