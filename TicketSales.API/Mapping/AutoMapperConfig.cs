using AutoMapper;
using TicketSales.Model.DTOs.CategoryDTO;
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

        }
    }
}
