using ECommerceApp.Application.Repositories;
using ECommerceApp.Application.RequestParameters;
using ECommerceApp.Application.ViewModels.Products;
using ECommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using MediatR;
using ECommerceApp.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceApp.Application.Features.Commands.ProductCommands.DeleteProduct;
using ECommerceApp.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceApp.Application.Features.Queries.ProductQueries.GetAllProduct;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        IMediator _mediator;

        public ProductsController(IProductWriteRepository productWriteRepository,
                                  IProductReadRepository productReadRepository,
                                  IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllProductQueryRequest());

            return Ok(response);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { StatusCode = 400 });

            var response = await _mediator.Send(request);

            return Ok(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(new { StatusCode = 200 });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(new { StatusCode = 200 });
        }

        [HttpPost("[action]")]
        public IActionResult Test(IFormFile file)
        {
            return Ok();
        }
    }
}
