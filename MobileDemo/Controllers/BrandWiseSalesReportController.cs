using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Model;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/salesreport")]
    [ApiController]
    public class BrandWiseSalesReportController : ControllerBase
    {
        private readonly IBrandWiseSalesReportService _salesReportService;

        public BrandWiseSalesReportController(IBrandWiseSalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        [HttpPost("brandwise")]
        public async Task<IActionResult> GetBrandWiseSalesReport([FromBody] BrandWiseSalesReportRequestParamDTO brandWiseSalesReportRequestParamDTO)
        {
            var brandWiseSalesReport = await _salesReportService.GetBrandWiseSalesReportAsync(brandWiseSalesReportRequestParamDTO);
            return Ok(brandWiseSalesReport);
        }
    }

}
