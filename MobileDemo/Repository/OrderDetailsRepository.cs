using Microsoft.EntityFrameworkCore;
using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{

    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly MobileStoreContext _context;

        public OrderDetailsRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetailsModel>> GetOrderDetailsAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetailsModel> GetOrderDetailByIdAsync(Guid id)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task<OrderDetailsModel> CreateOrderDetailAsync(OrderDetailsModel orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<OrderDetailsModel> UpdateOrderDetailAsync(Guid id, OrderDetailsModel orderDetail)
        {
            var existingOrderDetail = await _context.OrderDetails.FindAsync(id);
            if (existingOrderDetail == null)
            {
                return null;
            }

            _context.Entry(existingOrderDetail).CurrentValues.SetValues(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<bool> DeleteOrderDetailAsync(Guid id)
        {
            var existingOrderDetail = await _context.OrderDetails.FindAsync(id);
            if (existingOrderDetail == null)
            {
                return false;
            }

            _context.OrderDetails.Remove(existingOrderDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
