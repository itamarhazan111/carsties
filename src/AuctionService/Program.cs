using AuctionService.Data;
using AuctionService.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AuctionDbContext>(options=>{
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
try{
    DbInitializer.InitDb(app);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}

app.Run();