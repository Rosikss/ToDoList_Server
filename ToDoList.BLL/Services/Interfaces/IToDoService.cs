using ToDoList.BLL.DTO.ToDo;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Services.Interfaces;

public interface IToDoService
{
    Task<IEnumerable<ToDoDTO>> GetAllAsync();
    Task<ToDoDTO> GetByIdAsync(int id);
    Task<ToDoDTO> AddAsync(ToDoCreateDTO model);
    Task<ToDoDTO> UpdateAsync(ToDoUpdateDTO model);
    Task DeleteAsync(int id);
}