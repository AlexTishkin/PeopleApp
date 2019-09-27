using AutoMapper;
using PeopleApp.Core.Entity;

namespace PeopleApp.Core.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}