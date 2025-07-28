using AutoMapper;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.MongoModels;

namespace TaskManagement.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDocument>().ReverseMap();
            CreateMap<Comment, CommentDocument>().ReverseMap();
        }
    }
}