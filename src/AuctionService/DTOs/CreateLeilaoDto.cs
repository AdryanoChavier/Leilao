using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs
{
    public class CreateLeilaoDto
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public int Quilometragem { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int ReservaPreco { get; set; }

        [Required]
        public DateTime LeilaoEnd { get; set; }
    }
}
