using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL.DTO.ToDo;

public class ToDoUpdateDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public string? CreatedAt { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public string? DueDate { get; set; }
    [Required]
    [StringLength(500)]
    public string? Description { get; set; }
    [Required]
    public int StatusId { get; set; }
}