global using SimpleMVC.Data;
global using SimpleMVC.Models;
global using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SimpleMVC.Interfaces;
using SimpleMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Interface and Service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMessageService, MessageService>();


// Register connection string from appsetting.json
builder.Services.AddDbContext<ProductDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
