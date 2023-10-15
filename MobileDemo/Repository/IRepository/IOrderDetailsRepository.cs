using MobileDemo.Orders;

namespace MobileDemo.Repository.IRepository
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetailsModel>> GetOrderDetailsAsync();
        Task<OrderDetailsModel> GetOrderDetailByIdAsync(Guid id);
        Task<OrderDetailsModel> CreateOrderDetailAsync(OrderDetailsModel orderDetail);
        Task<OrderDetailsModel> UpdateOrderDetailAsync(Guid id, OrderDetailsModel orderDetail);
        Task<bool> DeleteOrderDetailAsync(Guid id);
    }
}
