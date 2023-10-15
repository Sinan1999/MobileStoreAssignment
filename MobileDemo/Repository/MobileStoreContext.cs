using Microsoft.EntityFrameworkCore;
using MobileDemo.Authentication;
using MobileDemo.Orders;

namespace MobileDemo.Repository
{
    public class MobileStoreContext : DbContext
    {
        public MobileStoreContext(DbContextOptions<MobileStoreContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DiscountModel> Discounts { get; set; }
        public DbSet<LineItemsModel> LineItems { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<PaymentDetailsModel> PaymentDetails { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<SalesReportModel> SalesReportModels { get; set; }
    }
}

