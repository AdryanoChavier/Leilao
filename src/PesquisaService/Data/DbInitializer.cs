using MongoDB.Driver;
using MongoDB.Entities;
using PesquisaService.Models;
using PesquisaService.Services;
using System.Text.Json;

namespace PesquisaService.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("PesquisaDb", MongoClientSettings
            .FromConnectionString(app.Configuration
            .GetConnectionString("MongoDbConnect")));

            await DB.Index<Item>()
                .Key(x => x.Marca, KeyType.Text)
                .Key(x => x.Modelo, KeyType.Text)
                .Key(x => x.Cor, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Item>();

            using var scope = app.Services.CreateScope();

            var httpClient = scope.ServiceProvider.GetRequiredService<LeilaoSvcHttpClient>();

            var items = await httpClient.GetItemsForPesquisaDb();

            if(items.Count > 0) await DB.SaveAsync(items);
        }
    }
}
