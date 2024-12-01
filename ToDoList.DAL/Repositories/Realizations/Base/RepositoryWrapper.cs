using ToDoList.DAL.Entities;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Base;
using ToDoList.DAL.Repositories.Interfaces.Statuses;
using ToDoList.DAL.Repositories.Interfaces.ToDos;
using ToDoList.DAL.Repositories.Realizations.Statuses;
using ToDoList.DAL.Repositories.Realizations.ToDos;

namespace ToDoList.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper, IDisposable
{
    private IStatusRepository<Status> _statusRepository;
    private IToDoRepository<ToDo> _toDoRepository;
    private readonly ApplicationDbContext _applicationDbContext;
    public RepositoryWrapper(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IStatusRepository<Status> StatusRepository
    {
        get
        {
            if (_statusRepository is null)
            {
                _statusRepository = new StatusRepository(_applicationDbContext);
            }

            return _statusRepository;
        }
    }
    
    public IToDoRepository<ToDo> ToDoRepository
    {
        get
        {
            if (_toDoRepository is null)
            {
                _toDoRepository = new ToDoRepository(_applicationDbContext);
            }

            return _toDoRepository;
        }
    }


    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _applicationDbContext.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}