using Dapper;
using PerformanceAnalysis.Reports.DayOfWeekActivity;
using PerformanceAnalysis.Reports.GroupLeadersAndLaggards;
using PerformanceAnalysis.Reports.GroupTread;
using PerformanceAnalysis.Reports.GroupTrend;
using PerformanceAnalysis.Reports.StudentMonthlyProgress;
using PerformanceAnalysis.Reports.StudentPassRate;
using PerformanceAnalysis.Reports.StudentPassRateSummary;
using PerformanceAnalysis.Reports.StudentRating;
using PerformanceAnalysis.Reports.StudentTestResults;
using PerformansysAnalys.Infrastructure.Reports;
using System.Data;
using System.Data.Common;

namespace PerformansysAnalys.Application.Reports
{
    public class ReportService : IReportService
    {

        private readonly IDbConnection _connection;

        public ReportService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<GroupLeadersAndLaggardsItem>> GetGroupLeadersAndLaggardsAsync(GroupLeadersAndLaggardsFilter filter)
        {
            return await _connection.QueryAsync<GroupLeadersAndLaggardsItem>(
                ReportQueries.GroupLeadersAndLaggards, filter);
        }

        public async Task<IEnumerable<StudentTestResultsItem>> GetStudentTestResultsAsync(StudentTestResultsFilter filter)
        {
           throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupTrendItem>> GetGroupTrendAsync(GroupTrendFilter filter)
        {
            return await _connection.QueryAsync<GroupTrendItem>(
                ReportQueries.GroupTrend,
                new { 
                    GroupIds = filter.GroupIds?.ToArray(), 
                    filter.DateFrom, 
                    filter.DateTo 
                    });
        }

        public async Task<IEnumerable<StudentRatingItem>> GetStudentRatingAsync(StudentRatingFilter filter)
        {
            return await _connection.QueryAsync<StudentRatingItem>(ReportQueries.StudentRating, filter);
        }

        public async Task<IEnumerable<StudentMonthlyProgressItem>> GetStudentMonthlyProgressAsync(StudentMonthlyProgressFilter filter)
        {
            return await _connection.QueryAsync<StudentMonthlyProgressItem>(ReportQueries.StudentMonthlyProgress, filter);
        }

        public async Task<IEnumerable<StudentPassRateItem>> GetStudentPassRateAsync(StudentPassRateFilter filter)
        {
          return await _connection.QueryAsync<StudentPassRateItem>(ReportQueries.StudentPassRate, filter);
        }

        public Task<StudentPassRateSummaryItem?> GetStudentPassRateSummaryAsync(StudentPassRateFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DayOfWeekActivityItem>> GetDayOfWeekActivityAsync(DayOfWeekActivityFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
