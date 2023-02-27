using FlightSimulator.Context;
using FlightSimulator.Entities;
using FlightSimulator.Interfaces;
using FlightSimulator.Repository;
using Logic.Interfaces;
using Logic.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")).EnableSensitiveDataLogging());

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITerminalRepository<Terminal>, TerminalRepository>();
//builder.Services.AddScoped<ILoggerRepository<Logger>, LoggerRepository>();
builder.Services.AddScoped<IBasicRepository<Logger>, LoggerRepository>();

builder.Services.AddScoped<ITerminalService, TerminalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
