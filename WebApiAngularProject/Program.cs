using Microsoft.EntityFrameworkCore;
using WebApiAngularProject.Data;
using WebApiAngularProject.Repositories;
using WebApiAngularProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddCors(options => options.AddDefaultPolicy(
//    builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});


var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
//assign the connection string to ApplicationDbContext class for CRUD
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAngularOrigins");


app.Run();
