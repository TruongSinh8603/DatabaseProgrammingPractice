using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SaleManager.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext()
            : base("ConnStr", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SaleManager.Models.ProductViewModel> ProductViewModels { get; set; }

        public System.Data.Entity.DbSet<SaleManager.Models.KhachHang> KhachHangs { get; set; }
    }
}