using System.Data.Entity;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Domain
{
	public class TestDbContext : DbContext
	{
		public TestDbContext()
			: base("MainDB")
		{
		}

		public DbSet<ContentPage> Pages { get; set; }

		public DbSet<CatalogSection> CatalogSections { get; set; }

		public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
	}
}
