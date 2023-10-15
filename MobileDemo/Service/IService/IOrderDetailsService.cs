using MobileDemo.Orders;

namespace MobileDemo.Service.IService
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetailsModel>> GetOrderDetailsAsync();
        Task<OrderDetailsModel> GetOrderDetailByIdAsync(Guid id);
        Task<OrderDetailsModel> CreateOrderDetailAsync(OrderDetailsModel orderDetail);
        Task<OrderDetailsModel> UpdateOrderDetailAsync(Guid id, OrderDetailsModel orderDetail);
        Task<bool> DeleteOrderDetailAsync(Guid id);
    }
}
