using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL.DTO.Status;

public class StatusUpdateDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
}