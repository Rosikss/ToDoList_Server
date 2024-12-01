﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.DTO.Status;

namespace ToDoList.BLL.DTO.ToDo
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public string DueDate { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
