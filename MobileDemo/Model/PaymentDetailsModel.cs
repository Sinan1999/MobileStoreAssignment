using Microsoft.EntityFrameworkCore;

namespace MobileDemo.Orders
{
    [PrimaryKey("Id")]
    public class PaymentDetailsModel
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
