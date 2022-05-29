using System.Collections.Generic;
using System.Threading.Tasks;
using CodeCampApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeCampApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateReportController : ControllerBase
    {
        private readonly ILogger<RateReportController> _logger;
        private readonly DataContext _context;

        public RateReportController(
            ILogger<RateReportController> logger,
            DataContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            return Ok(await _context.RateReports.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReport(int id)
        {
            var report = await _context.RateReports.FindAsync(id);

            if (report == null)
            {
                return BadRequest("report not found.");
            }

            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(RateReport rateReport)
        {
            _context.RateReports.Add(rateReport);
            await _context.SaveChangesAsync();
            return Ok(await _context.RateReports.ToListAsync());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReport(RateReport request, int id)
        {
            request.Id = id;
            var report = await _context.RateReports.FindAsync(id);

            if (report == null)
                return NotFound("report no found");

            report.Name = request.Name;
            report.FirstName = request.FirstName;
            report.LastName = request.LastName;
            report.Place = request.Place;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.RateReports.ToListAsync());
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = await _context.RateReports.FindAsync(id);

            if (report == null)
            {
                return BadRequest("report not found.");
            }

            _context.RateReports.Remove(report);
            await _context.SaveChangesAsync();

            return Ok(await _context.RateReports.ToListAsync());
        }
    }
}