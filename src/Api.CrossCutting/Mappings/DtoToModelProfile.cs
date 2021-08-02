using AutoMapper;
using Api.Domain.Dtos.User;
using Api.Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
            .ReverseMap();
        }
    }
}
