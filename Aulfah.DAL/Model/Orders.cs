using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime dateCraeted { get; set; } = DateTime.Now;


        [ForeignKey("Service")]
        public int? ServiceID { get; set; }
        public Service Service { get; set; }

        [ForeignKey("Track")]
        public int? TrackID { get; set; }
        public Tracking Track { get; set; }

        [ForeignKey("Shipment")]
        public int? ShipmentID { get; set; }
        public Shipment Shipment { get; set; }

        [ForeignKey("Payment")]
        public int? PaymentID { get; set; }
        public Payment Payment { get; set; }

        [ForeignKey("Cart")]
        public string? CartID { get; set; }
        public Cart Cart { get; set; }

    }
}
