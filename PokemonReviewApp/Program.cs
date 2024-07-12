using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPokemonInterface, PokemonRepository>();
builder.Services.AddScoped<ICategoryInterface, CategoryRepository>();
builder.Services.AddScoped<ICountryInterface, CountryRepository>();
builder.Services.AddScoped<IOwnerInterface, OwnerRepository>();
builder.Services.AddScoped<IReviewInterface, ReviewRepository>();
builder.Services.AddScoped<IReviewerInterface, ReviewerRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = String.Empty;
//if (builder.Environment.IsDevelopment())
//{
//    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
//    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
//}
//else
//{
//    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
//}

builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
