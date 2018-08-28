using Microsoft.EntityFrameworkCore;

namespace Gs.TestingBugManagement.Models
{
    public class AppDbContext : DbContext
    {
        #region Public Properties

        public DbSet<BugManagement> BugManagement { get; set; }

        #endregion
        #region Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       
        #endregion

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=tcp:personalserverhp.database.windows.net,1433;Initial Catalog=GsTestingBugManagement;Persist Security Info=False;User ID=Developer;Password=btjUAV4R;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
