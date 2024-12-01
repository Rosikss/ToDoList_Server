using ToDoList.DAL.Entities;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.ToDos;
using ToDoList.DAL.Repositories.Realizations.Base;

namespace ToDoList.DAL.Repositories.Realizations.ToDos;

public class ToDoRepository : RepositoryBase<ToDo>, IToDoRepository<ToDo>
{
    public ToDoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}