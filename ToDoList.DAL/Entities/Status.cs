using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Entities
{
    public class Status : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public List<ToDo> Todos { get; set; } = new List<ToDo>();
    }
}
