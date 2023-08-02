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
            CreateMap<UpdateUserVM, User>().ReverseMap();
            CreateMap<CreateContactVM, Contact>().ReverseMap();
            CreateMap<UpdateContactVM, Contact>().ReverseMap();
        }
    }
}
