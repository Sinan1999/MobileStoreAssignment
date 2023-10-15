using Microsoft.EntityFrameworkCore;
using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{

    public class PaymentDetailsRepository : IPaymentDetailsRepository
    {
        private readonly MobileStoreContext _context;

        public PaymentDetailsRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentDetailsModel>> GetPaymentDetailsAsync()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetailsModel> GetPaymentDetailByIdAsync(Guid id)
        {
            return await _context.PaymentDetails.FirstOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task<PaymentDetailsModel> CreatePaymentDetailAsync(PaymentDetailsModel paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();
            return paymentDetail;
        }

        public async Task<PaymentDetailsModel> UpdatePaymentDetailAsync(Guid id, PaymentDetailsModel paymentDetail)
        {
            var existingPaymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (existingPaymentDetail == null)
            {
                return null;
            }

            _context.Entry(existingPaymentDetail).CurrentValues.SetValues(paymentDetail);
            await _context.SaveChangesAsync();
            return paymentDetail;
        }

        public async Task<bool> DeletePaymentDetailAsync(Guid id)
        {
            var existingPaymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (existingPaymentDetail == null)
            {
                return false;
            }

            _context.PaymentDetails.Remove(existingPaymentDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
