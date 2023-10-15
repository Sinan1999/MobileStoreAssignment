using MobileDemo.Orders;

namespace MobileDemo.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProductByIdAsync(Guid id);
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task<ProductModel> UpdateProductAsync(Guid id, ProductModel product);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
