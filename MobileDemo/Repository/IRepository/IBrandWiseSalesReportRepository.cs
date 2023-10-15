using MobileDemo.Model;

namespace MobileDemo.Repository.IRepository
{
    public interface IBrandWiseSalesReportRepository
    {
        public Task<Dictionary<string, decimal>> GetBrandWiseSalesReportAsync(BrandWiseSalesReportRequestParamDTO brandWiseSalesReportRequestParamDTO);
    }
}
