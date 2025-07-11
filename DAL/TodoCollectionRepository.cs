using CommunityToolkit.Mvvm.Messaging;
using MauiTodos2.Entities;

namespace MauiTodos2.DAL;

public class TodoCollectionRepository(TodoDatabase database, IMessenger messenger) : ITodoCollectionRepository
{
    public IEnumerable<TodoCollection> GetAll()
    {
        var res = database.Collections.FindAll().ToList();
        return res;
    }

    public TodoCollection Get(int id) => database.Collections.FindById(id);
    public int Insert(TodoCollection collection)
    {
        var documentId = database.Collections.Insert(collection);
        return documentId.AsInt32;
    }

    public bool Update(TodoCollection collection) => database.Collections.Update(collection);
    public bool Delete(TodoCollection todoCollection)
    {
        var todos = database.Todos.Query().Where(t => t.Collections.Contains(todoCollection)).ToList();

        foreach (var todo in todos)
        {
            todo.Collections.Remove(todoCollection);
            database.Todos.Update(todo);
        }

        var wasDeleted = database.Collections.Delete(todoCollection.Id);
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
