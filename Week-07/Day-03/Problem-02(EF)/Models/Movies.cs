using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Movies
    {
        public int Id {  get; set; }
        [Required(ErrorMessage ="Title is mandatory"),StringLength(20,MinimumLength =4)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is mandatory"), StringLength(20, MinimumLength = 4)]
        public string Genre {  get; set; }

        [Required(ErrorMessage = "ReleaseDate is mandatory"),DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Price is mandatory"),Column(TypeName ="decimal(10,2)")]
        public decimal Price {  get; set; }
        public string Rating {  get; set; }
    }
}
