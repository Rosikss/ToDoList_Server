using System.ComponentModel.DataAnnotations;

namespace ToDoList.DAL.Entities;

public class Status : BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; }

    public List<ToDo> Todos { get; set; } = new List<ToDo>();
}