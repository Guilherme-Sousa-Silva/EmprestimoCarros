using EmprestimoCarros.API.Data;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.API.Repositories;
using EmprestimoCarros.API.Repositories.Car;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
	var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
	builder.Services.AddDbContext<Context>(options =>
	{
		options.UseSqlServer(connectionString);
	});

	builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
	builder.Services.AddScoped<ICarRepository, CarRepository>();
}
