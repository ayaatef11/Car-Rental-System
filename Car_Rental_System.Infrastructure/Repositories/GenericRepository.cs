using Car_Rental_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Repositories
{
    public class GenericRepository<T>where T:class
    {
        public AppDbContext _context { get; set; }
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

        }
        public void Delete(T entity) { 
        _context.Remove(entity);
            _context.SaveChanges();

        }

        public T Get(int id) {
            return _context.Set<T>().Find(id);
        }

        public T update(T entity) {

            //return _context.Set<T>().Update(entity); the type is entity<T> not T 
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<T> GetAll() {
            return _context.Set<T>().ToList();


        }
    }
}
