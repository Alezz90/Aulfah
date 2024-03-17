using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.Models
{
    public class Tracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        [Required]
        public string Status { get; set; } = "Order Submitted";
        [Required]
        public string Location { get; set; }

        //[ForeignKey("Orders")]
        //public int? OrdersID { get; set; }
        public Orders Orders { get; set; }
    }
}
