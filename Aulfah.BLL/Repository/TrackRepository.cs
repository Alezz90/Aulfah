using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;
using Aulfah.Models;
using System.Collections.Generic;
using System.Linq;

namespace Aulfah.DAL.Repositories
{
    public class TrackRepository : GenericRepository<Tracking>, ITrackRepository
    {
        private readonly ApplicationDBContext _context;

        public TrackRepository(ApplicationDBContext context): base (context)
        {
            _context = context;
        }

      
    }
}