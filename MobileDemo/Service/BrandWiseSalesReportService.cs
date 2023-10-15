using MobileDemo.Model;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{
    public class BrandWiseSalesReportService : IBrandWiseSalesReportService
    {
        private readonly IBrandWiseSalesReportRepository _brandWiseSalesReportRepository;

        public BrandWiseSalesReportService(IBrandWiseSalesReportRepository brandWiseSalesReportRepository)
        {
            _brandWiseSalesReportRepository = brandWiseSalesReportRepository;
        }

        public async Task<Dictionary<string, decimal>> GetBrandWiseSalesReportAsync(BrandWiseSalesReportRequestParamDTO brandWiseSalesReportRequestParamDTO)
        {
            return await _brandWiseSalesReportRepository.GetBrandWiseSalesReportAsync(brandWiseSalesReportRequestParamDTO);
        }
    }



}
