using AutoMapper;
using System.Diagnostics.Tracing;
using TicketSales.Model.DTOs.CategoryDTO;
using TicketSales.Model.DTOs.CityDTO;
using TicketSales.Model.DTOs.EventDTO;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            

            
            CreateMap<AddUserDTO, User>().ReverseMap();

            CreateMap<AddCategoryDTO, Category>().ReverseMap();

            CreateMap<AddCityDTO, City>().ReverseMap();

            CreateMap<AddEventDTO, Event>().ReverseMap();

            CreateMap<RegisterUserDTO, User>().ReverseMap();

        }
    }
}
