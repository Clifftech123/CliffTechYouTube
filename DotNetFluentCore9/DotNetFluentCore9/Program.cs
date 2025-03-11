using DotNetFluentCore9.Contracts;
using DotNetFluentCore9.Validators;
using FluentValidation;
using static DotNetFluentCore9.Validators.ProductItemValidator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IValidator<UserRegistrationRequest>, RegistrationValidator>();


builder.Services.AddScoped<IValidator<BusinessRegistrationRequest>, BusinessRegistrationValidator>();
builder.Services.AddScoped<IValidator<ProductCatalogRequest>, ProductCatalogValidator>();
builder.Services.AddScoped<IValidator<ShippingRequest>, ShippingValidator>();


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
