
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aulfah.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CartId { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double? totalPrice { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public Customer? Customers { get; set; }

        public void TotalPrice(List<Product> products)
        {
            foreach (var product in products)
            {
                totalPrice += product.ProductPrice;
            }
        }



    }
}
