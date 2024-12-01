using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.BLL.DTO.Status;
using ToDoList.BLL.DTO.ToDo;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.Services.Realizations;

public class ToDoService : IToDoService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public ToDoService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ToDoDTO>> GetAllAsync()
    {
        var entities = await _repositoryWrapper.ToDoRepository
            .GetAllAsync(include: queryable => queryable.Include(td => td.Status
            ));
        
        return _mapper.Map<IEnumerable<ToDoDTO>>(entities);
    }

    public async Task<ToDoDTO> GetByIdAsync(int id)
    {
        var entity = await _repositoryWrapper.ToDoRepository.GetFirstOrDefaultAsync(
            predicate: s => s.Id == id, 
            include: queryable => queryable.Include(td => td.Status
            ));
        
        return _mapper.Map<ToDoDTO>(entity);
    }

    public async Task<ToDoDTO> AddAsync(ToDoCreateDTO model)
    {
        var newEntity = _mapper.Map<ToDo>(model);
        var entity = await _repositoryWrapper.ToDoRepository.CreateAsync(newEntity);
        await _repositoryWrapper.SaveChangesAsync();
        return _mapper.Map<ToDoDTO>(entity);
    }

    public async Task<ToDoDTO> UpdateAsync(ToDoUpdateDTO model)
    {
        var updateEntity = _mapper.Map<ToDo>(model);
        var entity = _repositoryWrapper.ToDoRepository.Update(updateEntity);
        await _repositoryWrapper.SaveChangesAsync();
        return _mapper.Map<ToDoDTO>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repositoryWrapper.ToDoRepository.GetFirstOrDefaultAsync(s => s.Id == id);
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        _repositoryWrapper.ToDoRepository.Delete(entity);
        await _repositoryWrapper.SaveChangesAsync();
    }
}