using BuildingBlocks.Exceptions;
using Catalog.API.Endpoints.Category;
using Catalog.Application;
using Catalog.Infrastructure;
using Catalog.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices()
                .AddInfraStructureServices()
                .AddPersistanceServices(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler(options => { });

app.MapCategoryEndpoints();

app.UseHttpsRedirection();

app.Run();