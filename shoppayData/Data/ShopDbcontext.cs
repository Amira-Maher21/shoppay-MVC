 using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shoppayEntieys.Models;
using System.Configuration;

namespace shoppayData.Data
{
    public class ShopDbcontext : IdentityDbContext<IdentityUser>
    {
        public ShopDbcontext()
        {
 
		}

		public ShopDbcontext(DbContextOptions<ShopDbcontext> option) : base(option)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<ShoppinCart> shoppinCarts { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderHeader>(entity =>
			{
				entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
			});
		}




	}

}

