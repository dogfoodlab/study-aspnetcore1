using Microsoft.EntityFrameworkCore;

namespace study_aspnetcore1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options) { }

        public DbSet<AModel> AModels { get; set; }
        public DbSet<BModel> BModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=_data/context.db");
    }
}
