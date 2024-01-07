using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Models;
using StoreServices.Api.Book.Persistence;

namespace StoreServices.Api.Book.Application
{
    public class FilterQuery
    {
        public class SingleBook : IRequest<BookDto>{
            public Guid? BookId{ get; set; }
        }

        public class Handler : IRequestHandler<SingleBook, BookDto>
        {
            public readonly BookContext _context;
            private readonly IMapper _mapper;
            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BookDto> Handle(SingleBook request, CancellationToken cancellationToken)
            {
                var book = await _context.BookMaterial.Where(x => x.BookMaterialId == request.BookId).FirstOrDefaultAsync();
                if (book == null)
                {
                    throw new Exception("The book was not found");
                }
                var bookDto = _mapper.Map<BookMaterial, BookDto>(book);
                return bookDto;
            }
        }
    }
}
