using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Aulfah.DAL.Model;

namespace Aulfah.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        // Shaima Added Default Value
        public string? Status { get; set; } = "Pending";

     
        // public ICollection<Artist> Artists { get; set; } = new List<Artist>();
        //public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        [ForeignKey("Orders")]
        public int? OrdersID { get; set; }
        public Orders Orders { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}