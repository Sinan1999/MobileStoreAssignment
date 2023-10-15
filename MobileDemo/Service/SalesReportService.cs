using MobileDemo.Model;
using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{
    public class SalesReportService : ISalesReportService
    {
        private readonly ISalesReportRepository _salesReportRepository;

        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }

        public async Task<SalesResponseDTO> GetSalesReportAsync(SalesReportRequestParamDTO salesReportRequestParamDTO)
        {
            var result = await _salesReportRepository.GetSalesReportAsync(salesReportRequestParamDTO);
           return  new SalesResponseDTO() 
            {
                FromDate = result.FromDate,
                ToDate = result.ToDate,
                TotalSales = result.TotalSales,
            };
        }
    }
}
