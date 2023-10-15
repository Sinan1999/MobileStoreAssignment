using Microsoft.EntityFrameworkCore;
using MobileDemo.Model;
using MobileDemo.Repository.IRepository;

namespace MobileDemo.Repository
{
    public class BrandWiseSalesReportRepository : IBrandWiseSalesReportRepository
    {
        private readonly MobileStoreContext _context;

        public BrandWiseSalesReportRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, decimal>> GetBrandWiseSalesReportAsync(BrandWiseSalesReportRequestParamDTO brandWiseSalesReportRequestParamDTO)
        {

            var brandWiseSales = await _context.OrderDetails
                .Where(order => order.CreatedAt >= brandWiseSalesReportRequestParamDTO.FromDate && order.CreatedAt <= brandWiseSalesReportRequestParamDTO.ToDate)
                .Join(_context.ProductModels, order => order.ProductId, product => product.Id,
                    (order, product) => new { Brand = product.Brand, Total = order.Total })
                .GroupBy(item => item.Brand)
                .ToDictionaryAsync(group => group.Key, group => group.Sum(item => item.Total));

            return brandWiseSales;
        }
    }

}
