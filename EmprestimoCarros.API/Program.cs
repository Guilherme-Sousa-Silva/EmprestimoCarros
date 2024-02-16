using EmprestimoCarros.API.Mappings;
using EmprestimoCarros.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureSwagger();

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
	builder.Services.AddInfrastructure(builder.Configuration);
	//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
	//builder.Services.AddScoped<ICarRepository, CarRepository>();
	builder.Services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));

}