using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;

namespace Aulfah.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDBContext _context;

        public CustomerRepository(ApplicationDBContext context) : base (context) 
        {
            _context = context;
        }

      
    }
}