using CodeCampApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeCampApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<RateReport> RateReports { get; set; }
    }
}