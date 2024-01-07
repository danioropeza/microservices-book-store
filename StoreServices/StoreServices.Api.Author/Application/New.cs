using FluentValidation;
using MediatR;
using StoreServices.Api.Author.Models;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly AuthorContext _context;

            public Handler(AuthorContext context)
            {
                _context = context;
            }
            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                var bookAuthor = new BookAuthor
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    BookAuthorGuid = Convert.ToString(Guid.NewGuid()),
                };

                _context.BookAuthor.Add(bookAuthor);
                var value = await _context.SaveChangesAsync();

                if (value <= 0)
                {
                    throw new Exception("The author of the book could not be inserted");
                }
            }
        }
    }
}
