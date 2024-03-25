using Aulfah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.BLL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> Search(string? name, int? id);
        IEnumerable<Product> SearchCat(int id);
        IEnumerable<Product> UserProduct(string UserID);

        IEnumerable<Product> ProductList();
    }
}
