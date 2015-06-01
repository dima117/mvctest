using System.Data.Entity;

namespace Mvc.Study.Domain
{
	public class TestDbContext : DbContext
	{
		public TestDbContext()
			: base("MainDB")
		{
		}

		public DbSet<PageContent> Pages { get; set; }

        public DbSet<PageCatalog> Catalog { get; set; }
	}
}
