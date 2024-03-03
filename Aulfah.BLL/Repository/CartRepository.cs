using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;


namespace Aulfah.DAL.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context) : base(context) 
        {
            _context = context;
        }

       
    }
}