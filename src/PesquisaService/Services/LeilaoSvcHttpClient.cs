using MongoDB.Entities;
using PesquisaService.Models;

namespace PesquisaService.Services
{
    public class LeilaoSvcHttpClient
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public LeilaoSvcHttpClient(HttpClient httpClient, IConfiguration config)
        { 
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<Item>> GetItemsForPesquisaDb()
        {
            var lastUpdated = await DB.Find<Item, string>()
                .Sort(x => x.Descending(x => x.UpdatedAt)).
                Project(x => x.UpdatedAt.ToString())
                .ExecuteFirstAsync();
            return await _httpClient.GetFromJsonAsync<List<Item>>
                (_config["LeilaoServiceUrl"] + "/api/leilao?date=" + lastUpdated);
        }
    }
}
