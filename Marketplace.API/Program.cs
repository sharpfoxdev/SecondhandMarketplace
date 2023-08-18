using Marketplace.API.Data;
using Marketplace.API.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString = "server=localhost;user=testUser;password=testPassword;database=test;";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
// Replace 'YourDbContext' with the name of your own DbContext derived class.
builder.Services.AddDbContext<MarketplaceDbContext>(
	dbContextOptions => dbContextOptions
		.UseMySql(connectionString, serverVersion, options => options.UseNetTopologySuite())
		// The following three options help with debugging, but should
		// be changed or removed for production.
		.LogTo(Console.WriteLine, LogLevel.Information)
		.EnableSensitiveDataLogging()
		.EnableDetailedErrors()
);
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
/*builder.Services.AddDbContext<MarketplaceDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("MarketplaceConnectionString")));*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
