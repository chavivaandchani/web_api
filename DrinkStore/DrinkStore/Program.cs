using Repository;
using Services;
using Entity;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Microsoft.Extensions.Configuration;
using DrinkStore.Middleware;
using MyFirstWebApiSite.Middlwares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserDB, UserDB>();
builder.Services.AddScoped<IProductDB, ProductDB>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderDB, OrderDB>();
builder.Services.AddScoped<ICategoryDB, CategoryDB>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DrinksContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings")));
builder.Services.AddAutoMapper(typeof(IStartup));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSwaggerGen();
builder.Host.UseNLog();


var app = builder.Build();

//var app = builder.Build();

app.UseErrorsMiddleware();
app.UseRatingMiddleware();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
