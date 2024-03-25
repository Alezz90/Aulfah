using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Aulfah.DAL.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Aulfah.Models
{
    public class Product

    {
        public Product()
        {
            Images = new List<ProductImage>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        // Alezz add image to the produc
        //public string? ProductImage { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Users")]
        public string? Id { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<ProductImage> Images { get; set; }

        // alezz add category 
        [ForeignKey("category")]
        public int? CategoryID { get; set; }
        public ICollection<Category>? category { get; set; }
        //public ICollection<Cart>? Cart { get; set; } = new List<Cart>();

        public static decimal totalPrice(List<Product> products)
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += (decimal)product.ProductPrice;
            }
            return 0;
        }
    }
}