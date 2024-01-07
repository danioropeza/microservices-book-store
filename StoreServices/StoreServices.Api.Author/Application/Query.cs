using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Models;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDto>> { }

        public class Handler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.BookAuthor.ToListAsync();
                var authorsDto = _mapper.Map<List<BookAuthor>, List<AuthorDto>>(authors);
                return authorsDto;
            }
        }
    }
}
