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

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler(options => { });

app.UseStatusCodePages();

app.MapCategoryEndpoints();

app.UseHttpsRedirection();

app.Run();