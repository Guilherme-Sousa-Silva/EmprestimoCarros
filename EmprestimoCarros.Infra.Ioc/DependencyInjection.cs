using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.API.Mappings;
using EmprestimoCarros.API.Repositories;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Application.Services;
using EmprestimoCarros.Domain.Account;
using EmprestimoCarros.Domain.Interfaces;
using EmprestimoCarros.Infra.Data.Context;
using EmprestimoCarros.Infra.Data.Identity;
using EmprestimoCarros.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = configuration["jwt:issuer"],
					ValidAudience = configuration["jwt:audience"],
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
						ClockSkew = TimeSpan.Zero
				};
			});

			services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));

			// Repositories
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			// Services
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAuthenticate, AuthenticateService>();

			return services;
		}
	}
}
