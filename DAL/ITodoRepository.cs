using MauiTodos2.Entities;

namespace MauiTodos2.DAL;

public interface ITodoRepository : IRepository<Todo>
{
    IEnumerable<Todo> GetAll();
    Todo Get(int id);
    int Insert(Todo entity);
    bool Update(Todo entity);
    bool Delete(Todo entity);
    IEnumerable<Todo> GetTodosWithPagination(uint pageSize, uint firstItemIndex);
}





//// Collection operations

//// Todo-Collection relationship operations
//public void AddTodoToCollection(ObjectId todoId, ObjectId collectionId)
//{
//    var todo = Get(todoId);
//    if (todo == null) throw new ArgumentException("Todo not found");

//    if (!todo.Collections.Contains(collectionId))
//    {
//        todo.Collections.Add(collectionId);
//        database.Todos.Update(todo);
//    }
//}

//public void RemoveTodoFromCollection(ObjectId todoId, ObjectId collectionId)
//{
//    var todo = Get(todoId);
//    if (todo == null) throw new ArgumentException("Todo not found");

//    if (todo.Collections.Contains(collectionId))
//    {
//        todo.Collections.Remove(collectionId);
//        database.Todos.Update(todo);
//    }
//}

//public IEnumerable<Todo> GetTodosInCollection(ObjectId collectionId) =>
//    database.Todos.Find(t => t.CollectionIds.Contains(collectionId));

////public void UpdateTodo(Todo todo)
////{
////    _database.Todos.Update(todo);
////}
