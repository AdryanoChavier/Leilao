using MongoDB.Driver;
using MongoDB.Entities;
using PesquisaService.Models;
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

            if (count == 0)
            {
                Console.WriteLine("Sem dados");
                var itemData = await File.ReadAllTextAsync("Data/leiloes.json");

                var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

                var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);

                await DB.SaveAsync(items);
            }
        }
    }
}
