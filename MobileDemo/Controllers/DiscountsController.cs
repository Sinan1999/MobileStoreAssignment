using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Orders;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // GET: api/discounts
        [HttpGet]
        public async Task<IActionResult> GetDiscounts()
        {
            var discounts = await _discountService.GetDiscountsAsync();
            return Ok(discounts);
        }

        // GET: api/discounts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(Guid id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        // POST: api/discounts
        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountModel discount)
        {
            var createdDiscount = await _discountService.CreateDiscountAsync(discount);
            return CreatedAtAction(nameof(GetDiscount), new { id = createdDiscount.Id }, createdDiscount);
        }

        // PUT: api/discounts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscount(Guid id, [FromBody] DiscountModel discount)
        {
            var updatedDiscount = await _discountService.UpdateDiscountAsync(id, discount);
            if (updatedDiscount == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/discounts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(Guid id)
        {
            if (await _discountService.DeleteDiscountAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }

}
