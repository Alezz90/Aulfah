using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        
        int Create(T item);
        int Update(T item);
        int Delete(T item);
    }
}
