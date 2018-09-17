using Microsoft.EntityFrameworkCore;

namespace Gs.TestingBugManagement.Models
{
    public class AppDbContext : DbContext
    {
        #region Public Properties

        public DbSet<BugManagement> BugManagement { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlserverpersonaltest.database.windows.net,1433;Initial Catalog=GsTestingBugManagement;Persist Security Info=False;User ID=Developer;Password=btjUAV4R;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=False;");
        }
    }
}
