using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.DAL.Repositories;
using Aulfah.DataContex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.BLL.Repository
{
    public class ProductImageRepository:GenericRepository<ProductImage>,IProductImageRepository
    {
     
            private readonly ApplicationDBContext _context;

            public ProductImageRepository(ApplicationDBContext context) : base(context)
            {
                _context = context;
            }
        }
}
