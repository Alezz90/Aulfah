using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aulfah.Models
{
    public abstract class User
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public DateTime dateOfBirth { get; set; }
        public string? Region { get; set; }
        public string? State { get; set; }
        public string? Goverment { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone no. is required")]
        public int Phone { get; set; }
        public string? CardDate { get; set; }
        public int? SecurityKey { get; set; }
        public int? CardNum { get; set; }

        // Shaima add image to the User
        public string? UserImage { get; set; }

    }
}
