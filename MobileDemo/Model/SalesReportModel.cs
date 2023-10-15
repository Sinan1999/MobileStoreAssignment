using Microsoft.EntityFrameworkCore;

namespace MobileDemo.Orders
{
    [PrimaryKey("ID")]
    public class SalesReportModel
    {
        public Guid ID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal TotalSales { get; set; }
    }

}
