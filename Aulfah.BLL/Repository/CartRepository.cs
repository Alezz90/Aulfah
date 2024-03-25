using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;
using System.Xml.Linq;


namespace Aulfah.DAL.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context) : base(context) 
        {
            _context = context;
        }

        public IEnumerable<Cart> CustomerCart(string Userid)
        {
         
            var custCart = _context.Cart.Where(e => e.CartId == Userid).ToList();

            return custCart;
        }
    }
}