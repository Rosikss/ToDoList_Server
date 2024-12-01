using AutoMapper;
using ToDoList.BLL.DTO.Status;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.Services.Realizations;

public class StatusService : IStatusService
{

    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;
    public StatusService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StatusDTO>> GetAllAsync()
    {
        var entities = await _repositoryWrapper.StatusRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<StatusDTO>>(entities);
    }

    public async Task<StatusDTO> GetByIdAsync(int id)
    {
        var entity = await _repositoryWrapper.StatusRepository.GetFirstOrDefaultAsync(s => s.Id == id);
        return _mapper.Map<StatusDTO>(entity);
    }

    public async Task<StatusDTO> AddAsync(StatusCreateDTO model)
    {
        var newEntity = _mapper.Map<Status>(model);
        var entity = await _repositoryWrapper.StatusRepository.CreateAsync(newEntity);
        await _repositoryWrapper.SaveChangesAsync();
        return _mapper.Map<StatusDTO>(entity);
    }

    public async Task<StatusDTO> UpdateAsync(StatusUpdateDTO model)
    {
        var updateEntity = _mapper.Map<Status>(model);
        var entity = _repositoryWrapper.StatusRepository.Update(updateEntity);
        await _repositoryWrapper.SaveChangesAsync();
        return _mapper.Map<StatusDTO>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repositoryWrapper.StatusRepository.GetFirstOrDefaultAsync(s => s.Id == id);
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        _repositoryWrapper.StatusRepository.Delete(entity);
        await _repositoryWrapper.SaveChangesAsync();
    }
}