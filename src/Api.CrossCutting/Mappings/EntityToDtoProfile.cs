using AutoMapper;
using Api.Domain.Model;
using Api.Domain.Dtos.User;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
            .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
            .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
            .ReverseMap();
        }
    }
}