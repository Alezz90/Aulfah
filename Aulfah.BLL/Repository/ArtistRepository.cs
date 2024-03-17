using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.DataContex;
using Aulfah.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Aulfah.DAL.Repositories
{
    public class ArtistRepository :GenericRepository<ApplicationUser>,IArtistRepository
    {
        private readonly ApplicationDBContext _context;

        public ArtistRepository(ApplicationDBContext context):base(context) 
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> userservice(string id)
        {

            var user = _context.ApplicationUsers.Where(e => e.Id.Contains(id)).ToList();

            return user;
        }
        public IEnumerable<ApplicationUser> userProduct(string id)
        {
            var user = _context.ApplicationUsers
                    .Include(u => u.Products) // Eagerly load the products
                    .Where(u => u.Id == id)
                    .ToList();

            return user;
        }

    }
}
