using AutoMapper;
using ContactApp.Entities;
using ContactApp.ViewModels;

namespace ContactApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserVM, User>().ReverseMap();
        }
    }
}
