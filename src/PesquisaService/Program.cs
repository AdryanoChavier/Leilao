using MongoDB.Driver;
using MongoDB.Entities;
using PesquisaService.Data;
using PesquisaService.Models;
using PesquisaService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<LeilaoSvcHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

try
{
    await DbInitializer.InitDb(app);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}


app.Run();
