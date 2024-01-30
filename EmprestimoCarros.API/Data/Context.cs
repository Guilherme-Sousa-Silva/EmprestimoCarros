using EmprestimoCarros.API.Data.Mappings;
using EmprestimoCarros.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.API.Data
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base 
			(options) {
			AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
		}

        public DbSet<Customer> Customers { get; set; }
		public DbSet<Car> Cars { get; set; }
        public DbSet<CustomerLendingCar> customerLendingCars { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder options)
		//	=> options.UseSqlServer(@"Server=localhost,1433;Database=EmprestimoCarros;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerMap());
			modelBuilder.ApplyConfiguration(new CarMap());
			//modelBuilder.ApplyConfiguration(new CustomerLendingCarMap());
		}

	}
}
