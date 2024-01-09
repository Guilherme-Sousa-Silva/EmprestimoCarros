using EmprestimoCarros.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.API.Data
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base 
			(options) { }
        public DbSet<Customer> Customers { get; set; }
		public DbSet<Car> Cars { get; set; }
	}
}
