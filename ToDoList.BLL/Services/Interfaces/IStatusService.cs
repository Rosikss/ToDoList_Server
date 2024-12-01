using ToDoList.BLL.DTO.Status;

namespace ToDoList.BLL.Services.Interfaces;

public interface IStatusService
{
    Task<IEnumerable<StatusDTO>> GetAllAsync();
    Task<StatusDTO?> GetByIdAsync(int id);
    Task<StatusDTO> AddAsync(StatusCreateDTO statusCreateDto);
    Task<StatusDTO> UpdateAsync(StatusUpdateDTO statusUpdateDto);
    Task DeleteAsync(int id);
}