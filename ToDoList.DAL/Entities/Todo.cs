using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Entities
{
    public class ToDo : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public int StatusId { get; set; }
        public Status? StatusNavigation { get; set; }
    }
}
