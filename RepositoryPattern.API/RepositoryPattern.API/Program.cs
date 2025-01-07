using Microsoft.EntityFrameworkCore;
using RepositoryPattern.API.Data;
using RepositoryPattern.API.Domain.Mapping;
using RepositoryPattern.API.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });


builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});


builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
