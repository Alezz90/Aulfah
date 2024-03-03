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

        //ar categProducts = _dBContext.Category.Include(c => c.Products).ToList();
        // var user =_context.Services.Include(c=> c.).ToList();

        public IEnumerable<Service> Serveciuser(string id)
        {
            //  var user = _context.Services.Where(e => e.Artists.Contains(id));
           // var userServices = _context.Services.Where(service => service.User == id).ToList();

            return null;
        }

       /* IEnumerable<ApplicationUser> IServiceRepository.Serveciuser(Artist id)
        {
            var user = _context.Services.Where(e => e.Artists.Contains(id));

            return (IEnumerable<ApplicationUser>)user;
        }*/
    }
}