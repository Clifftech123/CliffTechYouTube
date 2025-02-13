using DependencyInjection.API.Interface;
using DependencyInjection.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRandomNumberService, RandomNumberService>();
builder.Services.AddScoped<ITimestampService, TimestampService>();
builder.Services.AddTransient<IUserSessionService, UserSessionService>();
builder.Services.AddTransient<IGuidGeneratorService, GuidGeneratorService>();



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
