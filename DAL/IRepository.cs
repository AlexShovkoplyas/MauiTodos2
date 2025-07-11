namespace MauiTodos2.DAL;

public interface IRepository<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    int Insert(T entity);
    bool Update(T entity);
    bool Delete(T entity);
}
