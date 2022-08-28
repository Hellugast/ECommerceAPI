using ECommerceAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), Name = "Product 1", Price = 1000 , CreatedDate = DateTime.UtcNow , Stock = 10},
                new(){Id = Guid.NewGuid(), Name = "Product 2", Price = 1000 , CreatedDate = DateTime.UtcNow , Stock = 20},
                new(){Id = Guid.NewGuid(), Name = "Product 3", Price = 1000 , CreatedDate = DateTime.UtcNow , Stock = 330}
            });
            await _productWriteRepository.SaveAsync();

        }
    }
}
