using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Orders;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        // GET: api/orderdetails
        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var orderDetails = await _orderDetailsService.GetOrderDetailsAsync();
            return Ok(orderDetails);
        }

        // GET: api/orderdetails/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(Guid id)
        {
            var orderDetail = await _orderDetailsService.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        // POST: api/orderdetails
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetailsModel orderDetail)
        {
            var createdOrderDetail = await _orderDetailsService.CreateOrderDetailAsync(orderDetail);
            return CreatedAtAction(nameof(GetOrderDetail), new { id = createdOrderDetail.Id }, createdOrderDetail);
        }

        // PUT: api/orderdetails/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(Guid id, [FromBody] OrderDetailsModel orderDetail)
        {
            var updatedOrderDetail = await _orderDetailsService.UpdateOrderDetailAsync(id, orderDetail);
            if (updatedOrderDetail == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/orderdetails/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            if (await _orderDetailsService.DeleteOrderDetailAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }

}
