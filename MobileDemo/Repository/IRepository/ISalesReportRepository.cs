using MobileDemo.Orders;

namespace MobileDemo.Repository.IRepository
{
    public interface ISalesReportRepository
    {
        public Task<SalesReportModel> GetSalesReportAsync(SalesReportRequestParamDTO salesReportRequestParamDTO);
    }
}
