using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class ApplicationDbContext: DbContext 
	{		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{
			
		}

		public ApplicationDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=ALEJANDRO\\SQLEXPRESS;Initial Catalog=DBStock;Integrated Security=True");
			}			
			
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<TStock> TStock { get; set; }		
	}
}
