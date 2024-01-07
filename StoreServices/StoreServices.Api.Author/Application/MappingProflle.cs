using AutoMapper;
using StoreServices.Api.Author.Models;

namespace StoreServices.Api.Author.Application
{
    public class MappingProflle : Profile
    {
        public MappingProflle()
        {
            CreateMap<BookAuthor, AuthorDto>();
        }
    }
}
