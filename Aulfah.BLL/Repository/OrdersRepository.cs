using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;

namespace Aulfah.DAL.Repositories
{
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        private readonly ApplicationDBContext _context;

        public OrdersRepository(ApplicationDBContext context): base (context)
        {
            _context = context;
        }

    }
}