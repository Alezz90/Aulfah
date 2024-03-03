using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;

namespace Aulfah.DAL.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDBContext _context;

        public PaymentRepository(ApplicationDBContext context) : base(context) 
        {
            _context = context;
        }


    }
}