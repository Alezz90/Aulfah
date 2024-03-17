using Aulfah.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.DAL.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LName { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string? Region { get; set; }
        public string? State { get; set; }
        public string? Goverment { get; set; }
        //public int? CartId { get; set; }

        /* Alrady IdentityUser Hase Phone Number */

        //[Phone]
        //[DataType(DataType.PhoneNumber)]
        //[Required(ErrorMessage = "Phone no. is required")]
        //public int Phone { get; set; }
        public string? CardDate { get; set; }
        public int? SecurityKey { get; set; }
        public int? CardNum { get; set; }

        // Shaima add image to the User
        public string? UserImage { get; set; }
        //public IFormFile ProductPath { get; set; }


        // [ForeignKey("ServiceID")]
        // public int ServiceID { get; set; }
        // public Service service { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();

        public ICollection<Product> Products { get; set; }

    }
}
