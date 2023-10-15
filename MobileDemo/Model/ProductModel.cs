using Microsoft.EntityFrameworkCore;

namespace MobileDemo.Orders
{
    [PrimaryKey("Id")]
    public class ProductModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public decimal? Price { get; set; }
    }
}
