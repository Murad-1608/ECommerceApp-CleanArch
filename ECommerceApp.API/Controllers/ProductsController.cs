using ECommerceApp.Application.Repositories;
using ECommerceApp.Application.RequestParameters;
using ECommerceApp.Application.ViewModels.Products;
using ECommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository,
                                  IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] Pagination pagination)
        {
            return Ok(_productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { StatusCode = 400 });

            await _productWriteRepository.AddAsync(new Product()
            {
                Name = viewModel.Name,
                Stock = viewModel.Stock,
                Price = viewModel.Price
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductViewModel viewModel)
        {
            Product product = await _productReadRepository.GetByIdAsync(viewModel.Id);
            product.Name = viewModel.Name;
            product.Stock = viewModel.Stock;
            product.Price = viewModel.Price;
            await _productWriteRepository.SaveAsync();

            return Ok(new { StatusCode = 200 });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok(new { StatusCode = 200 });
        }

        [HttpPost("[action]")]
        public IActionResult Test(IFormFile file)
        {
            return Ok();
        }
    }
}
