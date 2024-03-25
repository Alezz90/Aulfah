using Aulfah.BLL.Interfaces;
using Aulfah.DataContex;

namespace Aulfah.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(string id)
        {

            return _context.Set<T>().Find(id);
        }

        public int Create(T item)
        {
            _context.Set<T>().Add(item);
            return _context.SaveChanges();
        }

        public int Update(T item)
        {
            _context.Set<T>().Update(item);
            return _context.SaveChanges();
        }

        public int Delete(T item)
        {
            _context.Set<T>().Remove(item);
            return _context.SaveChanges();
        }
    }
}