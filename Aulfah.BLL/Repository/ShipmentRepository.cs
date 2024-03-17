using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;

namespace Aulfah.DAL.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        private readonly ApplicationDBContext _context;

        public ShipmentRepository(ApplicationDBContext context) :base (context)
        {
            _context = context;
        }

      
    }
}