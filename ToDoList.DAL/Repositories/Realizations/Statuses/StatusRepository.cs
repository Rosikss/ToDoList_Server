using ToDoList.DAL.Entities;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Statuses;
using ToDoList.DAL.Repositories.Realizations.Base;

namespace ToDoList.DAL.Repositories.Realizations.Statuses;

public class StatusRepository : RepositoryBase<Status>, IStatusRepository
{
    public StatusRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}