using MobileDemo.Orders;

namespace MobileDemo.Repository.IRepository
{
    public interface IPaymentDetailsRepository
    {
        Task<IEnumerable<PaymentDetailsModel>> GetPaymentDetailsAsync();
        Task<PaymentDetailsModel> GetPaymentDetailByIdAsync(Guid id);
        Task<PaymentDetailsModel> CreatePaymentDetailAsync(PaymentDetailsModel paymentDetail);
        Task<PaymentDetailsModel> UpdatePaymentDetailAsync(Guid id, PaymentDetailsModel paymentDetail);
        Task<bool> DeletePaymentDetailAsync(Guid id);
    }
}
