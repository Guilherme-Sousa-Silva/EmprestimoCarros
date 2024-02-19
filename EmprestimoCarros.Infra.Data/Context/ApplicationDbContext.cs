using EmprestimoCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.Infra.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<CustomerLendingCar> CustomerLendingCars { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
