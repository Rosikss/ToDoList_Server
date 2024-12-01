using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL.DTO.Status;

public class StatusCreateDTO
{
    [Required]
    public string Name { get; set; }
}