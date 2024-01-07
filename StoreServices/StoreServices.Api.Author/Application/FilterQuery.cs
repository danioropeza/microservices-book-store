using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Models;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class FilterQuery
    {
        public class UniqueAuthor : IRequest<AuthorDto>{
            public string GuidAuthor { get; set; }
        }

        public class Handler : IRequestHandler<UniqueAuthor, AuthorDto>
        {
            public readonly AuthorContext _context;
            private readonly IMapper _mapper;
            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<AuthorDto> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.BookAuthor.Where(x => x.BookAuthorGuid == request.GuidAuthor).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("The author was not found");
                }
                var authorDto = _mapper.Map<BookAuthor, AuthorDto>(author);
                return authorDto;
            }
        }
    }
}
