using Microsoft.EntityFrameworkCore;
using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{

    public class LineItemsRepository : ILineItemsRepository
    {
        private readonly MobileStoreContext _context;

        public LineItemsRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LineItemsModel>> GetLineItemsAsync()
        {
            return await _context.LineItems.ToListAsync();
        }

        public async Task<LineItemsModel> GetLineItemByIdAsync(Guid id)
        {
            return await _context.LineItems.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<LineItemsModel> CreateLineItemAsync(LineItemsModel lineItem)
        {
            _context.LineItems.Add(lineItem);
            await _context.SaveChangesAsync();
            return lineItem;
        }

        public async Task<LineItemsModel> UpdateLineItemAsync(Guid id, LineItemsModel lineItem)
        {
            var existingItem = await _context.LineItems.FindAsync(id);
            if (existingItem == null)
            {
                return null;
            }

            _context.Entry(existingItem).CurrentValues.SetValues(lineItem);
            await _context.SaveChangesAsync();
            return lineItem;
        }

        public async Task<bool> DeleteLineItemAsync(Guid id)
        {
            var existingItem = await _context.LineItems.FindAsync(id);
            if (existingItem == null)
            {
                return false;
            }

            _context.LineItems.Remove(existingItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
