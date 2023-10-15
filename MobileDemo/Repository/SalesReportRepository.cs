using Microsoft.EntityFrameworkCore;
using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{

    public class SalesReportRepository : ISalesReportRepository
    {
        private readonly MobileStoreContext _context;

        public SalesReportRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<SalesReportModel> GetSalesReportAsync(SalesReportRequestParamDTO salesReportRequestParamDTO)
        {

            var salesData = await _context.OrderDetails
                .Where(order => order.CreatedAt >= salesReportRequestParamDTO.FromDate && order.CreatedAt <= salesReportRequestParamDTO.ToDate)
                .ToListAsync();

            decimal totalSales = salesData.Sum(order => order.Total);

            var salesReport = new SalesReportModel
            {
                FromDate = salesReportRequestParamDTO.FromDate,
                ToDate = salesReportRequestParamDTO.ToDate,
                TotalSales = totalSales
            };

            return salesReport;
        }
    }
}
