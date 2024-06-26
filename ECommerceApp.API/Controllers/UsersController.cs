﻿using ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser;
using ECommerceApp.Application.Features.Commands.AppUserCommands.GoogleLogin;
using ECommerceApp.Application.Features.Commands.AppUserCommands.LoginUser;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserCommandRequest request)
        {

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
