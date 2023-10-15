using MobileDemo.Model;
using MobileDemo.Orders;

namespace MobileDemo.Service.IService
{
    public interface ISalesReportService
    {
        Task<SalesResponseDTO> GetSalesReportAsync(SalesReportRequestParamDTO salesReportRequestParamDTO);
    }
}
