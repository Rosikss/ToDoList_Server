using System.ComponentModel.DataAnnotations;

namespace ToDoList.DAL.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}