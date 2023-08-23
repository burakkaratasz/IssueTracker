using IssueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Issue> Issues { get; set; } //database kaydı
    }
}
