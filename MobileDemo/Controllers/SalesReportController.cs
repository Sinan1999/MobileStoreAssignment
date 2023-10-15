using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Orders;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/salesreport")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        private readonly ISalesReportService _salesReportService;

        public SalesReportController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        // GET: api/salesreport?fromDate=yyyy-MM-dd&toDate=yyyy-MM-dd
        [HttpPost]
        public async Task<IActionResult> GetSalesReport([FromBody] SalesReportRequestParamDTO salesReportRequestParamDTO)
        {
            var salesReport = await _salesReportService.GetSalesReportAsync(salesReportRequestParamDTO);
            return Ok(salesReport);
        }
    }

}
