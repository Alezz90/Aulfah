using Aulfah.DAL.Model;
using Aulfah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.BLL.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {

        IEnumerable<Service> Serveciuser(string id);
    }
}
