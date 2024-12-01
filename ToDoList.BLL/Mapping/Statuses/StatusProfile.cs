using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList.BLL.DTO.Status;
using ToDoList.BLL.DTO.ToDo;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Mapping.Statuses
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<StatusUpdateDTO, Status>().ReverseMap();
            CreateMap<StatusCreateDTO, Status>();
        }
    }
}
