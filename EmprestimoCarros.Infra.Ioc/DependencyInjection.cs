using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.API.Mappings;
using EmprestimoCarros.API.Repositories;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Application.Services;
using EmprestimoCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmprestimoCarros.Infra.Ioc
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
			b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
			});

			services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));

			// Repositories
			services.AddScoped<ICustomerRepository, CustomerRepository>();

			// Services
			services.AddScoped<ICustomerService, CustomerService>();

			return services;
		}
	}
}
