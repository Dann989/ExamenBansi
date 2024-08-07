using MX.BANSI.CORE.DLL.Application.Interfaces;
using MX.BANSI.CORE.DLL.Application.Services;
using MX.BANSI.CORE.DLL.DOMAIN.Entities;
using MX.BANSI.CORE.DLL.DOMAIN.Interfaces;
using MX.BANSI.CORE.DLL.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using MX.BANSI.CORE.DLL.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddScoped<IRepository<Examen>, ExamenRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IExamenService, ExamenService>();

// Agregar y configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Examen API",
        Version = "v1",
        Description = "API para gestionar exámenes",
        Contact = new OpenApiContact
        {
            Name = "Daniel Benitez",
            Email = "danielbenitez93@yahoo.com",
            Url = new Uri("https://tusitio.com"),
        }
    });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configurar Middleware

app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examen API v1");
});

app.UseHttpsRedirection();

// Configurar Endpoints

app.MapGet("/api/examenes", async (IExamenService examenService) =>
{
    var examenes = await examenService.GetAllExamenesAsync();
    return Results.Ok(examenes);
});

app.MapGet("/api/examenes/{id}", async (int id, IExamenService examenService) =>
{
    var examen = await examenService.GetExamenByIdAsync(id);
    return examen is not null ? Results.Ok(examen) : Results.NotFound();
});

app.MapPost("/api/examenes", async (Examen examen, IExamenService examenService) =>
{
    await examenService.CreateExamenAsync(examen);
    return Results.Created($"/api/examenes/{examen.Id}", examen);
});

app.MapPut("/api/examenes/{id}", async (int id, Examen examen, IExamenService examenService) =>
{
    if (id != examen.Id)
    {
        return Results.BadRequest();
    }

    var existingExamen = await examenService.GetExamenByIdAsync(id);
    if (existingExamen is null)
    {
        return Results.NotFound();
    }

    await examenService.UpdateExamenAsync(examen);
    return Results.NoContent();
});

app.MapDelete("/api/examenes/{id}", async (int id, IExamenService examenService) =>
{
    var examen = await examenService.GetExamenByIdAsync(id);
    if (examen is null)
    {
        return Results.NotFound();
    }

    await examenService.DeleteExamenAsync(id);
    return Results.NoContent();
});

app.Run();