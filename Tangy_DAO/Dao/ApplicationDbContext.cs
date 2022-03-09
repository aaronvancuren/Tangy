using Microsoft.EntityFrameworkCore;

namespace Tangy_Dao.Dao
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
	}
}