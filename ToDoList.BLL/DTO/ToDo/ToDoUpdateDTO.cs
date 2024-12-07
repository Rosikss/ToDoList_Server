﻿using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL.DTO.ToDo;

public class ToDoUpdateDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    public string? Description { get; set; }
    public int StatusId { get; set; }
}