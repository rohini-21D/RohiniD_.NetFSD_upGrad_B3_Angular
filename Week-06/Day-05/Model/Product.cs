using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required]
        public int ProdId { get; set; }
        [Required]
        [Length(5,15)]
        public string? ProdName { get; set; }
        [Required]
        [Length(5,15)]
        public string? ProdCategory {  get; set; }
        [Required]
        [Range(1,1000000)]
        public decimal ProdPrice { get; set; }

    }
}
