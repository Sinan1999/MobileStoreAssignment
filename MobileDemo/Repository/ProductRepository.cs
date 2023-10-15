using MobileDemo.Orders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MobileDemo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MobileDemo.Repository
{


    public class ProductRepository : IProductRepository
    {
        private readonly MobileStoreContext _context;

        public ProductRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return await _context.ProductModels.ToListAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id)
        {
            return await _context.ProductModels.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {
            _context.ProductModels.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductModel> UpdateProductAsync(Guid id, ProductModel product)
        {
            var existingProduct = await _context.ProductModels.FindAsync(id);
            if (existingProduct == null)
            {
                return null;
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var existingProduct = await _context.ProductModels.FindAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            _context.ProductModels.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
