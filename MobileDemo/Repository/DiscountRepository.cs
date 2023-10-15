using Microsoft.EntityFrameworkCore;
using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{

    public class DiscountRepository : IDiscountRepository
    {
        private readonly MobileStoreContext _context;

        public DiscountRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiscountModel>> GetDiscountsAsync()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<DiscountModel> GetDiscountByIdAsync(Guid id)
        {
            return await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DiscountModel> CreateDiscountAsync(DiscountModel discount)
        {
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<DiscountModel> UpdateDiscountAsync(Guid id, DiscountModel discount)
        {
            var existingDiscount = await _context.Discounts.FindAsync(id);
            if (existingDiscount == null)
            {
                return null;
            }

            _context.Entry(existingDiscount).CurrentValues.SetValues(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> DeleteDiscountAsync(Guid id)
        {
            var existingDiscount = await _context.Discounts.FindAsync(id);
            if (existingDiscount == null)
            {
                return false;
            }

            _context.Discounts.Remove(existingDiscount);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
