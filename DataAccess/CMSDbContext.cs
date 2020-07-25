using Microsoft.EntityFrameworkCore;

namespace CMS.DataAccess
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext()
        {

        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<WebsiteConfiguration> websiteConfigurations { get; set; }
        public DbSet<PageSEO> PageSEOs { get; set; }
        public DbSet<Paragraph> Paragraph { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=cms.db");
        }
    }
}
