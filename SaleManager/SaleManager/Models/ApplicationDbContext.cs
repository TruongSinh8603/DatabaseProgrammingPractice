using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SaleManager.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public ApplicationDbContext()
        : base("ConnStr", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}