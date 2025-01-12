using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AuctionService.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<LeilaoDbContext>());

        }
        private static void SeedData(LeilaoDbContext context)
        {
            context.Database.Migrate();

            if (context.Leiloes.Any())
            {
                Console.WriteLine("Já existem dados - não é necessário inserir dados iniciais.");
                return;

            }

            var leiloes = new List<Leilao>()
            {
                new Leilao
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Ativo,
                ReservaPreco = 20000,
                Vendedor = "bob",
                LeilaoEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Marca = "Ford",
                    Modelo = "GT",
                    Cor = "Branco",
                    Quilometragem = 50000,
                    Ano = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Ativo,
                ReservaPreco = 90000,
                Vendedor = "alice",
                LeilaoEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Marca = "Bugatti",
                    Modelo = "Veyron",
                    Cor = "Preto",
                    Quilometragem = 15035,
                    Ano = 2018,
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Ativo,
                Vendedor = "bob",
                LeilaoEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Marca = "Ford",
                    Modelo = "Mustang",
                    Cor = "Preto",
                    Quilometragem = 65125,
                    Ano = 2023,
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReservaNaoAtingida,
                ReservaPreco = 50000,
                Vendedor = "tom",
                LeilaoEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Marca = "Mercedes",
                    Modelo = "SLK",
                    Cor = "Prata",
                    Quilometragem = 15001,
                    Ano = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Ativo,
                ReservaPreco = 20000,
                Vendedor = "alice",
                LeilaoEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Marca = "BMW",
                    Modelo = "X1",
                    Cor = "Branco",
                    Quilometragem = 90000,
                    Ano = 2017,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Ativo,
                ReservaPreco = 20000,
                Vendedor = "bob",
                LeilaoEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Marca = "Ferrari",
                    Modelo = "Spider",
                    Cor = "Vermelho",
                    Quilometragem = 50000,
                    Ano = 2015,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Ativo,
                ReservaPreco = 150000,
                Vendedor = "alice",
                LeilaoEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Marca = "Ferrari",
                    Modelo = "F-430",
                    Cor = "Vermelho",
                    Quilometragem = 5000,
                    Ano = 2022,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Ativo,
                Vendedor = "bob",
                LeilaoEnd = DateTime.UtcNow.AddDays(19),
                Item = new Item
                {
                    Marca = "Audi",
                    Modelo = "R8",
                    Cor = "Branco",
                    Quilometragem = 10050,
                    Ano = 2021,
                    ImageUrl = "https://cdn.pixabay.com/photo/2019/12/26/20/50/audi-r8-4721217_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Ativo,
                ReservaPreco = 20000,
                Vendedor = "tom",
                LeilaoEnd = DateTime.UtcNow.AddDays(20),
                Item = new Item
                {
                    Marca = "Audi",
                    Modelo = "TT",
                    Cor = "Preto",
                    Quilometragem = 25400,
                    Ano = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/09/01/15/06/audi-1636320_960_720.jpg"
                }
            },
            new Leilao
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Ativo,
                ReservaPreco = 20000,
                Vendedor = "bob",
                LeilaoEnd = DateTime.UtcNow.AddDays(48),
                Item = new Item
                {
                    Marca = "Ford",
                    Modelo = "Model T",
                    Cor = "Ferrugem",
                    Quilometragem = 150150,
                    Ano = 1938,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/08/02/19/47/vintage-2573090_960_720.jpg"
                }
            }

            };

            context.AddRange(leiloes);

            context.SaveChanges();

        }
    }
} 
