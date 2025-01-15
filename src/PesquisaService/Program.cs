using MongoDB.Driver;
using MongoDB.Entities;
using PesquisaService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("PesquisaDb", MongoClientSettings
    .FromConnectionString(builder.Configuration
    .GetConnectionString("MongoDbConnect")));

await DB.Index<Item>()
    .Key(x => x.Marca, KeyType.Text)
    .Key(x => x.Modelo, KeyType.Text)
    .Key(x => x.Cor, KeyType.Text)
    .CreateAsync();

app.Run();
