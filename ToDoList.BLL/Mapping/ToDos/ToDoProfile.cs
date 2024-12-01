using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList.BLL.DTO.ToDo;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Mapping.ToDos
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoDTO>().ReverseMap();
            CreateMap<ToDoUpdateDTO, ToDo>().ReverseMap();
            CreateMap<ToDoCreateDTO, ToDo>();
        }
    }
}
