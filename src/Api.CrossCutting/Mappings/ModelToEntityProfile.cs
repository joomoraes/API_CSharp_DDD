using AutoMapper;
using Api.Domain.Model;
using Api.Domain.Dtos.User;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
            .ReverseMap();
        }
    }
}