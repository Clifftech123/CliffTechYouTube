using DotnetAzureCosmosDb.Contracts;
using DotnetAzureCosmosDb.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen();

// Adding services to the container
builder.Services.AddSingleton<IStudentService>(builder.Configuration.GetSection("CosmosDb").InitializeCosmosClientInstanceAsync().GetAwaiter().GetResult());


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
