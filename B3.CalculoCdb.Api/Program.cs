using System.Diagnostics.CodeAnalysis;
using B3.CalculoCdb.Api.DI;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjection();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "B3.CalculoCdb.Api",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Camilla Batista",
            Email = "camillabatista1995@gmail.com"
        }
    });

    var xmlFile = "B3.CalculoCdb.Api.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.RunAsync();

[ExcludeFromCodeCoverage]
public static partial class Program { }