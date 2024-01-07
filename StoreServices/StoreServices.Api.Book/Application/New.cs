using FluentValidation;
using MediatR;
using StoreServices.Api.Book.Models;
using StoreServices.Api.Book.Persistence;

namespace StoreServices.Api.Book.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? PublicationDate { get; set; }
            public Guid? BookAuthor { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublicationDate).NotEmpty();
                RuleFor(x => x.BookAuthor).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly BookContext _context;

            public Handler(BookContext context)
            {
                _context = context;
            }
            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new BookMaterial
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    BookAuthor = request.BookAuthor,
                };
                _context.BookMaterial.Add(book);

                var value = await _context.SaveChangesAsync();

                if (value <= 0)
                {
                    throw new Exception("The book could not be inserted");
                }
            }
        }
    }
}
