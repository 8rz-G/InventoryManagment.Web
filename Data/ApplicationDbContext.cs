using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagment.Web.Models.Entities;

namespace InventoryManagment.Web.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Laptop> Laptops { get; set; }
		public DbSet<Display> Monitors { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Producer> Producers { get; set; }
		public DbSet<HardwareModel> HardwareModels { get; set; }
		public DbSet<InventoryChange> InventoryChanges { get; set; }
	}
}
