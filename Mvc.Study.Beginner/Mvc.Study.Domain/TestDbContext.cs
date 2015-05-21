using System.Data.Entity;

namespace Mvc.Study.Domain
{
	public class TestDbContext : DbContext
	{
		public TestDbContext()
			: base("MainDB")
		{
		}

		public DbSet<Page> Pages { get; set; }
	}
}
