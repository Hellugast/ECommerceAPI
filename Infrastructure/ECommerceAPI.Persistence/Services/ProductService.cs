using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using System.Text.Json;

namespace ECommerceAPI.Persistence.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductReadRepository _productReadRepository;
        private readonly IQRCodeService _qRCodeService;

        public ProductService(IProductReadRepository productReadRepository, IQRCodeService qRCodeService)
        {
            _productReadRepository = productReadRepository;
            _qRCodeService = qRCodeService;
        }

        public async Task<byte[]> QrCodeForProductAsync(string productId)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedDate
            };

            string plainText = JsonSerializer.Serialize(plainObject);

            return _qRCodeService.GenerateQRCode(plainText);

        }
    }
}
