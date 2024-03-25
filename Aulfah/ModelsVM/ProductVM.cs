using Aulfah.DAL.Model;
using Aulfah.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aulfah.PL.ModelsVM
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
       
        public string? Description { get; set; }
        public string? Size { get; set; }
        [ForeignKey("Users")]
        public string? Id { get; set; }
        public int Quantity { get; set; }
        public int? CategoryID { get; set; }
        public Category category { get; set; }
        public string? productimage { get; set; }
        public IFormFile productpath { get; set; }
         public virtual List<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}
