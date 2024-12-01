
using dotnet9_crash_course.src.Domain.Validators;
using dotnet9_crash_course.src.Infrastructure.Context;
using dotnet9_crash_course.src.Infrastructure.Exceptions;
using dotnet9_crash_course.src.Infrastructure.Mapping;
using dotnet9_crash_course.src.Service;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using static dotnet9_crash_course.src.Domain.Contract.ProductsContracts;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Adds services to the container.
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// Configures OpenAPI.
/// </summary>
builder.Services.AddOpenApi();

/// <summary>
/// Adds endpoints API explorer.
/// </summary>
builder.Services.AddEndpointsApiExplorer();

/// <summary>
/// Adds problem details.
/// </summary>
builder.Services.AddProblemDetails();

/// <summary>
/// Adds global exception handler.
/// </summary>
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

/// <summary>
/// Configures Swagger.
/// </summary>
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "dotnet9_crash_course", Version = "v1" });
});

/// <summary>
/// Registers validators.
/// </summary>
builder.Services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();

/// <summary>
/// Registers AutoMapper.
/// </summary>
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

/// <summary>
/// Registers services.
/// </summary>
builder.Services.AddScoped<IProductService, ProductService>();

/// <summary>
/// Registers the DbContext.
/// </summary>
builder.Services.AddDbContext<ProductDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

var app = builder.Build();

/// <summary>
/// Configures the HTTP request pipeline.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();
app.Run();
