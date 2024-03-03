using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.DataContex;
using Aulfah.Models;
using Microsoft.EntityFrameworkCore;

namespace Aulfah.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context): base(context)
        {
            _context = context;
        }
        public IEnumerable<Product> Search(string? name,int? id)
        {
            /* var prod = _context.Product.Where(((e => e.ProductName.ToLower().Contains(name.ToLower())).ToList();*/
            var prod = _context.Product.Where(e => e.ProductName.ToLower().Contains(name.ToLower()) && (id == null || e.CategoryID == id));

            return prod;
        }
    
        public IEnumerable<Product> SearchCat(int id)
        {
          
            var prod = _context.Product.Where(e => e.CategoryID == id).ToList();
         
            return prod;
        }
    }
}