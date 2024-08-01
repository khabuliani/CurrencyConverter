using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ValuteConverter.Core.Repositories;

namespace ValuteConverter.EntityFrameworkCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ValuteConverterDbContext _context;

        public Repository(ValuteConverterDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] propertySelectors)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Single(predicate);
        }

        public T FirstOrDefault(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public int InsertAndGetId(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            var entityEntry = _context.Entry(entity);
            return (int)entityEntry.Property("Id").CurrentValue;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }
    }
}
