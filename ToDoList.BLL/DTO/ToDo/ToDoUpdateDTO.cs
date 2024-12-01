using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BLL.DTO.ToDo
{
    public class ToDoUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string DueDate { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
