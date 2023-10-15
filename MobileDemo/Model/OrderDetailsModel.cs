using Microsoft.EntityFrameworkCore;

namespace MobileDemo.Orders
{
    [PrimaryKey("Id")]
    public class OrderDetailsModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? UserId { get; set; }
        public string? PaymentId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
