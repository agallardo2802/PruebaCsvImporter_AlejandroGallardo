using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
	public class ApplicationDbContext: DbContext 
	{		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
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
