using MobileDemo.Orders;

namespace MobileDemo.Service.IService
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountModel>> GetDiscountsAsync();
        Task<DiscountModel> GetDiscountByIdAsync(Guid id);
        Task<DiscountModel> CreateDiscountAsync(DiscountModel discount);
        Task<DiscountModel> UpdateDiscountAsync(Guid id, DiscountModel discount);
        Task<bool> DeleteDiscountAsync(Guid id);
    }
}
