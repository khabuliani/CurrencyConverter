using System.Linq.Expressions;

namespace ValuteConverter.Core.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();

    IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] propertySelectors);

    T Get(int id);

    T Single(Expression<Func<T, bool>> predicate);

    T FirstOrDefault(int id);

    T FirstOrDefault(Expression<Func<T, bool>> predicate);

    T Insert(T entity);

    int InsertAndGetId(T entity);

    T Update(T entity);

    void Delete(int id);

    int Count();

}
