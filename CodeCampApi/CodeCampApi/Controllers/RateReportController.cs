using System.Collections.Generic;
using System.Threading.Tasks;
using CodeCampApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeCampApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateReportController : ControllerBase
    {
        private static List<RateReport> rateReports = new List<RateReport>
        {
            new RateReport
            {
                Id = 1,
                Name = "Dollar",
                FirstName = "John",
                LastName = "Parker",
                Place = "USA"
            }
        };

        private readonly ILogger<RateReportController> _logger;

        public RateReportController(ILogger<RateReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            return Ok(rateReports);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReport(int id)
        {
            var report = rateReports.Find(key => key.Id == id);

            if (report == null)
            {
                return BadRequest("report not found.");
            }

            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(RateReport rateReport)
        {
            rateReports.Add(rateReport);
            return Ok(rateReports);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReport(RateReport request, int id)
        {
            request.Id = id;
            var report = rateReports.Find(key => key.Id == request.Id);

            if (report == null)
                return NotFound("report no found");

            report.Name = request.Name;
            report.FirstName = request.FirstName;
            report.LastName = request.LastName;
            report.Place = request.Place;

            
            return Ok(report);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = rateReports.Find(key => key.Id == id);

            if (report == null)
                return NotFound("report no found");

            rateReports.Remove(report);

            return Ok(report);
        }
    }
}