using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data
{
    public class LeilaoDbContext : DbContext
    {
        public LeilaoDbContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<Leilao> Leiloes { get; set; }
    }
}
