using MediatR;
using StoreServices.Api.ShoppingCart.Models;
using StoreServices.Api.ShoppingCart.Persistence;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime? SessionCreationDate { get; set; }
            public List<string> Products { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ShoppingCartContext _context;

            public Handler(ShoppingCartContext context)
            {
                _context = context;
            }
            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                var shoppingCartSession = new ShoppingCartSession
                {
                    CreationDate = request.SessionCreationDate,
                };

                _context.ShoppingCartSession.Add(shoppingCartSession);
                var value = await _context.SaveChangesAsync();
                if (value <= 0)
                {
                    throw new Exception("The shopping cart session could not be inserted");
                }
                int id = shoppingCartSession.ShoppingCartSessionId;

                foreach(var product in request.Products)
                {
                    var shoppingCartSessionDetail = new ShoppingCartSessionDetail
                    {
                        CreationDate = DateTime.Now,
                        ShoppingCartSessionId = id,
                        SelectedProduct = product
                    };
                    _context.ShoppingCartSessionDetail.Add(shoppingCartSessionDetail);
                }

                value = await _context.SaveChangesAsync();

                if (value <= 0)
                {
                    throw new Exception("The shopping cart details could not be inserted");
                }
            }
        }
    }
}
