using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.ShoppingCart.Application;

namespace StoreServices.Api.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(New.Execute data)
        {
            await _mediator.Send(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartSessionDto>> GetShoppingCart(int id)
        {
            return await _mediator.Send(new Query.Execute { ShoppingCartSessionId = id });
        }
    }
}
