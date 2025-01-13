
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ScalarOpenApi.Data;
using ScalarOpenApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddProblemDetails();

builder.Services.AddScoped<IStudent, StudentService>();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
