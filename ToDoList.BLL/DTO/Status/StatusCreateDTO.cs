using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL.DTO.Status;

public class StatusCreateDTO
{
    public string? Name { get; set; }
    public string? Color { get; set; }
}