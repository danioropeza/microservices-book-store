

using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Models;

namespace StoreServices.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(New.Execute data)
        {
            await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetBookAuthorById(string id)
        {
            return await _mediator.Send(new FilterQuery.UniqueAuthor { GuidAuthor = id });
        }
    }
}
