using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiAngularProject.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? Productname { get; set; }


        [Required]
        public decimal Productprice { get; set; }

        [ForeignKey("ProductId")]
        public int CategoryId { get; set; }
       

        public string? imageUrl { get; set; }
    }
}
