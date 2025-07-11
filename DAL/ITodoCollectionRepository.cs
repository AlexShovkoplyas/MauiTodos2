using MauiTodos2.Entities;

namespace MauiTodos2.DAL;

public interface ITodoCollectionRepository : IRepository<TodoCollection>
{
    IEnumerable<TodoCollection> GetAll();
    TodoCollection Get(int id);
    int Insert(TodoCollection entity);
    bool Update(TodoCollection entity);
    bool Delete(TodoCollection entity);
}
