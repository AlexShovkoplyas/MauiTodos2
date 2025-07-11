using CommunityToolkit.Mvvm.Messaging;
using MauiTodos2.Entities;

namespace MauiTodos2.DAL;

public class TodoRepository(TodoDatabase database, IMessenger messenger) : ITodoRepository
{
    public IEnumerable<Todo> GetTodosWithPagination(uint pageSize, uint firstItemIndex)
    {
        return database.Todos
            .Include(x => x.Collections)
            .Query()
            .OrderBy(x => x.Id)
            .Offset((int)firstItemIndex)
            .Limit((int)pageSize)
            .ToList();
    }

    public IEnumerable<Todo> GetAll() => database.Todos.FindAll();
    public Todo Get(int id) => database.Todos.FindById(id);

    public int Insert(Todo todo)
    {
        var documentId = database.Todos.Insert(todo);
        return documentId.AsInt32;
    }

    public bool Update(Todo todo)
    {
        var result = database.Todos.Update(todo);
        return result;
    }

    public bool Delete(Todo todo)
    {
        var wasDeleted = database.Todos.Delete(todo.Id);
        return wasDeleted;
    }
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
