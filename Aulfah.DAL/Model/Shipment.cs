using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.Models
{
    public class Shipment
    {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ShipmentID { get; set; }
            [Required]
            public string Totalsize { get; set; }
            [Required]
            public string Type { get; set; }
            public ICollection<Orders> Orders { get; set; } = new List<Orders>();
        }
}
