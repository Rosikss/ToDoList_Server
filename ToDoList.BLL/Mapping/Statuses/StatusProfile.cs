using AutoMapper;
using ToDoList.BLL.DTO.Status;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Mapping.Statuses;

public class StatusProfile : Profile
{
    public StatusProfile()
    {
        CreateMap<Status, StatusDTO>().ReverseMap();
        CreateMap<StatusUpdateDTO, Status>().ReverseMap();
        CreateMap<StatusCreateDTO, Status>();

            
    }
}