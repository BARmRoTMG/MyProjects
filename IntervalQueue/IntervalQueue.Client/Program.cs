using IntervalQueue.Client.Mappers;
using IntervalQueue.Client.Models;
using IntervalQueue.Data.Context;
using IntervalQueue.Data.Entities;
using IntervalQueue.Data.Interfaces;
using IntervalQueue.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QueueDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddScoped<IRepository<Customer>, QueueRepository>();
builder.Services.AddScoped<IMapper<Customer, CustomerDto>, ModelMapper>();

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Queue}/{action=Index}/{id?}");

app.Run();
