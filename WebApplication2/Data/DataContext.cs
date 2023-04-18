global using Microsoft.EntityFrameworkCore;
namespace WebApplication2.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base (options) 
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superhero_db;Trusted_Connection=true;TrustServerCertificate=true;");
		}

		public DbSet<superhero> superheroes { get; set; }


	}
}
