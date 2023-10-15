﻿using MobileDemo.Orders;

namespace MobileDemo.Repository.IRepository
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<DiscountModel>> GetDiscountsAsync();
        Task<DiscountModel> GetDiscountByIdAsync(Guid id);
        Task<DiscountModel> CreateDiscountAsync(DiscountModel discount);
        Task<DiscountModel> UpdateDiscountAsync(Guid id, DiscountModel discount);
        Task<bool> DeleteDiscountAsync(Guid id);
    }
}
