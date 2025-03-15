using MauiAppPrueba.API.ServiceExtension;
using MauiAppPrueba.Application.Services;
using MauiAppPrueba.Domain.Entities;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Domain.UnitOfWork;
using MauiAppPrueba.Infrastructure.Data;
using MauiAppPrueba.Infrastructure.Repositories;
using MauiAppPrueba.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MauiAppPrueba.API", Version = "v1" });
});

builder.Services.AddCustomServices(builder.Configuration);
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IEmployeeServices, EmployeeService>();


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
   app.UseSwagger();
   app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MauiAppPrueba.API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
