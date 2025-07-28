using AuthAndUser.Domain.Entities;
using AuthAndUser.Infrastructure.MongoModels;
using AutoMapper;


namespace AuthAndUser.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDocument>().ReverseMap();
            CreateMap<UserLogin, UserLoginDocument>().ReverseMap();
        }
    }
}