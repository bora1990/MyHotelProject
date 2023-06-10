using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class   //For EntityFrameWork Core
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
            // dinamik olarak belirtilen türdeki bir DbSet nesnesini döndürerek, o türle ilişkili olan veritabanı tablosuna erişmenizi sağlar.
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
