using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<IEnumerable<DiscountModel>> GetDiscountsAsync()
        {
            return await _discountRepository.GetDiscountsAsync();
        }

        public async Task<DiscountModel> GetDiscountByIdAsync(Guid id)
        {
            return await _discountRepository.GetDiscountByIdAsync(id);
        }

        public async Task<DiscountModel> CreateDiscountAsync(DiscountModel discount)
        {
            return await _discountRepository.CreateDiscountAsync(discount);
        }

        public async Task<DiscountModel> UpdateDiscountAsync(Guid id, DiscountModel discount)
        {
            return await _discountRepository.UpdateDiscountAsync(id, discount);
        }

        public async Task<bool> DeleteDiscountAsync(Guid id)
        {
            return await _discountRepository.DeleteDiscountAsync(id);
        }
    }
}
