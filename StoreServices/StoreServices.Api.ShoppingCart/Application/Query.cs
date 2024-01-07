using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Persistence;
using StoreServices.Api.ShoppingCart.RemoteInterfaces;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class Query
    {
        public class Execute : IRequest<ShoppingCartSessionDto>
        {
            public int ShoppingCartSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, ShoppingCartSessionDto>
        {
            private readonly ShoppingCartContext _context;
            private readonly IBooksService _booksService;

            public Handler(ShoppingCartContext context, IBooksService booksService)
            {
                _context = context;
                _booksService = booksService;
            }

            public async Task<ShoppingCartSessionDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var shoppingCartSession = await _context.ShoppingCartSession.FirstOrDefaultAsync(x => 
                    x.ShoppingCartSessionId == request.ShoppingCartSessionId
                );
                var shoppingCartSessionDetail = await _context.ShoppingCartSessionDetail.Where(x =>
                    x.ShoppingCartSessionId == request.ShoppingCartSessionId
                ).ToListAsync();

                var shoppingCartsDetails = new List<ShoppingCartSessionDetailDto>();

                foreach(var book in shoppingCartSessionDetail)
                {
                    var response = await _booksService.GetBook(new Guid(book.SelectedProduct));
                    if(response.result)
                    {
                        var bookObject = response.book;
                        var shoppingCartDetail = new ShoppingCartSessionDetailDto
                        {
                            BookTitle = bookObject.Title,
                            PublicationDate = bookObject.PublicationDate,
                            BookId = bookObject.BookMaterialId
                        };

                        shoppingCartsDetails.Add(shoppingCartDetail);
                    }
                }

                var shoppingCartSessionDto = new ShoppingCartSessionDto
                {
                    ShoppingCartSessionId = shoppingCartSession.ShoppingCartSessionId,
                    SessionCreationDate = shoppingCartSession.CreationDate,
                    Products = shoppingCartsDetails
                };

                return shoppingCartSessionDto;
            }
        }
    }
}
