using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAnalysis.Reports.GroupLeadersAndLaggards;
using PerformanceAnalysis.Reports.GroupTrend;
using PerformanceAnalysis.Reports.StudentMonthlyProgress;
using PerformanceAnalysis.Reports.StudentRating;
using PerformanceAnalysis.Reports.StudentTestResults;
using PerformansysAnalys.Application.Reports;

namespace PerformansysAnalys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("group-leaders")]
        public async Task<IActionResult> GetGroupLeaders([FromQuery] GroupLeadersAndLaggardsFilter filter)
        {
            var result = await _reportService.GetGroupLeadersAndLaggardsAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-test-results")]
        public async Task<IActionResult> GetStudentTestResults([FromQuery] StudentTestResultsFilter filter)
        {
            var result = await _reportService.GetStudentTestResultsAsync(filter);
            return Ok(result);
        }

        [HttpGet("group-trend")]
        public async Task<IActionResult> GetGroupTrend([FromQuery] GroupTrendFilter filter)
        {
            var result = await _reportService.GetGroupTrendAsync(filter);
            return Ok(result);
        }


        [HttpGet("student-monthly-progress")]
        public async Task<IActionResult> GetStudentMonthlyProgress([FromQuery] StudentMonthlyProgressFilter filter)
        {
            var result = await _reportService.GetStudentMonthlyProgressAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-rating")]
        public async Task<IActionResult> GetStudentRating([FromQuery] StudentRatingFilter filter)
        {
            var result = await _reportService.GetStudentRatingAsync(filter);
            return Ok(result);
        }


    }
}
