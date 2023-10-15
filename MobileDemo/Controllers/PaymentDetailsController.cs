using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Orders;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/paymentdetails")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IPaymentDetailsService _paymentDetailsService;

        public PaymentDetailsController(IPaymentDetailsService paymentDetailsService)
        {
            _paymentDetailsService = paymentDetailsService;
        }

        // GET: api/paymentdetails
        [HttpGet]
        public async Task<IActionResult> GetPaymentDetails()
        {
            var paymentDetails = await _paymentDetailsService.GetPaymentDetailsAsync();
            return Ok(paymentDetails);
        }

        // GET: api/paymentdetails/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentDetail(Guid id)
        {
            var paymentDetail = await _paymentDetailsService.GetPaymentDetailByIdAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            return Ok(paymentDetail);
        }

        // POST: api/paymentdetails
        [HttpPost]
        public async Task<IActionResult> CreatePaymentDetail([FromBody] PaymentDetailsModel paymentDetail)
        {
            var createdPaymentDetail = await _paymentDetailsService.CreatePaymentDetailAsync(paymentDetail);
            return CreatedAtAction(nameof(GetPaymentDetail), new { id = createdPaymentDetail.Id }, createdPaymentDetail);
        }

        // PUT: api/paymentdetails/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentDetail(Guid id, [FromBody] PaymentDetailsModel paymentDetail)
        {
            var updatedPaymentDetail = await _paymentDetailsService.UpdatePaymentDetailAsync(id, paymentDetail);
            if (updatedPaymentDetail == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/paymentdetails/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(Guid id)
        {
            if (await _paymentDetailsService.DeletePaymentDetailAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }

}
