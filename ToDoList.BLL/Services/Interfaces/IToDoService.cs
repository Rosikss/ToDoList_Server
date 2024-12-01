using ToDoList.BLL.DTO.ToDo;

namespace ToDoList.BLL.Services.Interfaces;

public interface IToDoService
{
    Task<IEnumerable<ToDoDTO>> GetAllAsync();
    Task<ToDoDTO?> GetByIdAsync(int id);
    Task<ToDoDTO> AddAsync(ToDoCreateDTO toDoCreateDto);
    Task<ToDoDTO> UpdateAsync(ToDoUpdateDTO toDoUpdateDto);
    Task DeleteAsync(int id);
}