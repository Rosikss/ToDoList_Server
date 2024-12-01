using System.ComponentModel.DataAnnotations;

namespace ToDoList.DAL.Entities;

public class ToDo : BaseEntity
{
    [MaxLength(50)]
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }

    public int StatusId { get; set; }
    public Status? Status { get; set; }
}