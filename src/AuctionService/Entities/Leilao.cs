namespace AuctionService.Entities
{
    public class Leilao
    {
        public Guid  Id { get; set; }
        public int ReservaPreco { get; set; } = 0;
        public string Vendedor { get; set; }
        public string Ganhador { get; set; }
        public int? QuantidadeVendida { get; set; }
        public int? AtualOferta { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LeilaoEnd {  get; set; }
        public Status Status { get; set; }
        public Item Item { get; set; }
    }
}
