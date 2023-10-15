using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{
    public class PaymentDetailService : IPaymentDetailsService
    {
        private readonly IPaymentDetailsRepository _paymentDetailsRepository;

        public PaymentDetailService(IPaymentDetailsRepository paymentDetailsRepository)
        {
            _paymentDetailsRepository = paymentDetailsRepository;
        }

        public async Task<IEnumerable<PaymentDetailsModel>> GetPaymentDetailsAsync()
        {
            return await _paymentDetailsRepository.GetPaymentDetailsAsync();
        }

        public async Task<PaymentDetailsModel> GetPaymentDetailByIdAsync(Guid id)
        {
            return await _paymentDetailsRepository.GetPaymentDetailByIdAsync(id);
        }

        public async Task<PaymentDetailsModel> CreatePaymentDetailAsync(PaymentDetailsModel paymentDetail)
        {
            return await _paymentDetailsRepository.CreatePaymentDetailAsync(paymentDetail);
        }

        public async Task<PaymentDetailsModel> UpdatePaymentDetailAsync(Guid id, PaymentDetailsModel paymentDetail)
        {
            return await _paymentDetailsRepository.UpdatePaymentDetailAsync(id, paymentDetail);
        }

        public async Task<bool> DeletePaymentDetailAsync(Guid id)
        {
            return await _paymentDetailsRepository.DeletePaymentDetailAsync(id);
        }
    }
}
