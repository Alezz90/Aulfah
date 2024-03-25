using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.DataContex;
using Aulfah.Models;
using Microsoft.EntityFrameworkCore;

namespace Aulfah.DAL.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly ApplicationDBContext _context;

        public ServiceRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Service> UserServices(string Userid)
        {
            var prod = _context.Services.Where(e => e.ServiceID.ToString()  == Userid).ToList();

            return prod;
        }

      
    }
}