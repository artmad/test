using MegaCurrency.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MegaNote.Controllers.v1
{
    
    [ApiController]
    [Route("api/v1/reports")]
    public class ReportsController : ControllerBase
    {

        private readonly ICurrencyReportService _currencyReportService;
        public ReportsController(ICurrencyReportService currencyReportService)
        {
            _currencyReportService = currencyReportService;
        }

        [HttpGet("currency")]
        public IActionResult GetAll()
        {
            var result = _currencyReportService.GetReport();
            return Ok(result);
        }
    }
}
