using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Orders;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/lineitems")]
    [ApiController]
    public class LineItemsController : ControllerBase
    {
        private readonly ILineItemsService _lineItemsService;

        public LineItemsController(ILineItemsService lineItemsService)
        {
            _lineItemsService = lineItemsService;
        }

        // GET: api/lineitems
        [HttpGet]
        public async Task<IActionResult> GetLineItems()
        {
            var lineItems = await _lineItemsService.GetLineItemsAsync();
            return Ok(lineItems);
        }

        // GET: api/lineitems/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLineItem(Guid id)
        {
            var lineItem = await _lineItemsService.GetLineItemByIdAsync(id);
            if (lineItem == null)
            {
                return NotFound();
            }
            return Ok(lineItem);
        }

        // POST: api/lineitems
        [HttpPost]
        public async Task<IActionResult> CreateLineItem([FromBody] LineItemsModel lineItem)
        {
            var createdLineItem = await _lineItemsService.CreateLineItemAsync(lineItem);
            return CreatedAtAction(nameof(GetLineItem), new { id = createdLineItem.Id }, createdLineItem);
        }

        // PUT: api/lineitems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLineItem(Guid id, [FromBody] LineItemsModel lineItem)
        {
            var updatedLineItem = await _lineItemsService.UpdateLineItemAsync(id, lineItem);
            if (updatedLineItem == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/lineitems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineItem(Guid id)
        {
            if (await _lineItemsService.DeleteLineItemAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }

}
