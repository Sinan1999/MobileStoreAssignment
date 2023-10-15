using MobileDemo.Model;

namespace MobileDemo.Service.IService
{
    public interface IBrandWiseSalesReportService
    {
        public Task<Dictionary<string, decimal>> GetBrandWiseSalesReportAsync(BrandWiseSalesReportRequestParamDTO brandWiseSalesReportRequestParamDTO);
    }
}
