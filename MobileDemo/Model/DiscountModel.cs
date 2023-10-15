using Microsoft.EntityFrameworkCore;

namespace MobileDemo.Orders
{
    [PrimaryKey("Id")]
    public class DiscountModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
