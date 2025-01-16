namespace Contracts;

public class LeilaoCreated
{
    public Guid Id { get; set; }
    public int ReservaPreco { get; set; } = 0;
    public string Vendedor { get; set; }
    public string Ganhador { get; set; }
    public int QuantidadeVendida { get; set; }
    public int AtualOferta { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LeilaoEnd { get; set; }
    public string Status { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    public int Quilometragem { get; set; }
    public string ImageUrl { get; set; }
}
