using AdventureWorks.Data.Contexts;
using AdventureWorks.Data.Models.Person;
using AdventureWorks.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AdventureWorksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IRepository<Person>, PersonRepository>();

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













//THE PACKAGE MANAGER CODE
//Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=AdventureWorks2017;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -d -context AdventureWorksDbContext -contextDir Contexts -outputDir Models/Person -schema Person -project AdventureWorks.Data -startupProject AdventureWorks.Client
