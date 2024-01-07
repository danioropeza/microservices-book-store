using AutoMapper;
using StoreServices.Api.Book.Models;

namespace StoreServices.Api.Book.Application
{
    public class MappingProfile
    {
        public class MappingProflle : Profile
        {
            public MappingProflle()
            {
                CreateMap<BookMaterial, BookDto>();
            }
        }
    }
}
