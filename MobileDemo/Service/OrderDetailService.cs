using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{

    public class OrderDetailService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<IEnumerable<OrderDetailsModel>> GetOrderDetailsAsync()
        {
            return await _orderDetailsRepository.GetOrderDetailsAsync();
        }

        public async Task<OrderDetailsModel> GetOrderDetailByIdAsync(Guid id)
        {
            return await _orderDetailsRepository.GetOrderDetailByIdAsync(id);
        }

        public async Task<OrderDetailsModel> CreateOrderDetailAsync(OrderDetailsModel orderDetail)
        {
            return await _orderDetailsRepository.CreateOrderDetailAsync(orderDetail);
        }

        public async Task<OrderDetailsModel> UpdateOrderDetailAsync(Guid id, OrderDetailsModel orderDetail)
        {
            return await _orderDetailsRepository.UpdateOrderDetailAsync(id, orderDetail);
        }

        public async Task<bool> DeleteOrderDetailAsync(Guid id)
        {
            return await _orderDetailsRepository.DeleteOrderDetailAsync(id);
        }
    }
}
