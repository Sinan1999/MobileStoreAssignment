using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<ProductModel> UpdateProductAsync(Guid id, ProductModel product)
        {
            return await _productRepository.UpdateProductAsync(id, product);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
    }
}
