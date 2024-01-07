using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Models;
using StoreServices.Api.Book.Persistence;

namespace StoreServices.Api.Book.Application
{
    public class Query
    {
        public class BookList : IRequest<List<BookDto>> { }

        public class Handler : IRequestHandler<BookList, List<BookDto>>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BookDto>> Handle(BookList request, CancellationToken cancellationToken)
            {
                var books = await _context.BookMaterial.ToListAsync();
                var booksDto = _mapper.Map<List<BookMaterial>, List<BookDto>>(books);
                return booksDto;
            }
        }
    }
}
