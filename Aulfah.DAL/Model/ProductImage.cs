using Aulfah.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.DAL.Model
{
  
    public class ProductImage
    {
        public ProductImage() { 
        
        }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile productpath { get; set; }

        [ForeignKey("ProductImages")]
        public int? ProductId { get; set; }
        public ICollection<Product> ProductImages { get; set; }
    }
}
