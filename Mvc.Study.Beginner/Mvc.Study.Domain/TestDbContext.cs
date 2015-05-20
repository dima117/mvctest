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

		public DbSet<Page> Pages { get; set; }
	}
}
