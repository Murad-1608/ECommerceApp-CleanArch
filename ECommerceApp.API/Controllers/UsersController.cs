using ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Create(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(new { StatusCode = 200 });
        }
    }
}
