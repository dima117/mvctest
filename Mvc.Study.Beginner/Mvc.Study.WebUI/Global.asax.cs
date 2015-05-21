using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

	        InitDatabase();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

		private void InitDatabase()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestDbContext, TestMigrationsConfiguration>());

			using (var context = new TestDbContext())
			{
				context.Database.Initialize(false);
			}
		}

		public sealed class TestMigrationsConfiguration : DbMigrationsConfiguration<TestDbContext>
		{
			public TestMigrationsConfiguration()
			{
				AutomaticMigrationsEnabled = true;
				AutomaticMigrationDataLossAllowed = true;
			}

			protected override void Seed(TestDbContext context)
			{

			}
		}
    }
}