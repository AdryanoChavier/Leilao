namespace AuctionService.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public int Quilometragem { get; set; }
        public string ImageUrl { get; set; }
        public Leilao Leilao { get; set; }
        public Guid LeilaoId { get; set; }

    }
}
