using Aulfah.DAL.Model;
using Aulfah.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Aulfah.PL.ModelsVM
{
    public class CategoryListproduct
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
