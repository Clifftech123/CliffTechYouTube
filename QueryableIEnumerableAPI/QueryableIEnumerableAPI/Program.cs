using Microsoft.EntityFrameworkCore;
using QueryableIEnumerableAPI.Constract;
using QueryableIEnumerableAPI.Data;
using QueryableIEnumerableAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=employee.db"));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();