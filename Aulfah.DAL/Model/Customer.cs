

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Aulfah.DAL.Model;

namespace Aulfah.Models
{
  
    public class Customer : ApplicationUser
    {

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

       


    }
}
