using Microsoft.EntityFrameworkCore;
using NewPetShop.Client.Mappers;
using NewPetShop.Client.Models;
using NewPetShop.Data.Context;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Interfaces;
using NewPetShop.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PetShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
builder.Services.AddScoped<IMapper<Animal, AnimalDto>, ModelMapper>();
builder.Services.AddScoped<ILogin<User>, UserRepository>();
builder.Services.AddMemoryCache();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
