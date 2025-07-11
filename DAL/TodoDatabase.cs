using LiteDB;
using MauiTodos2.Entities;

namespace MauiTodos2.DAL;

public class TodoDatabase : IDisposable
{
    private const string Todos_Collection = "todos";
    private const string Collections_Collection = "collections";

    private readonly LiteDatabase _db;

    public TodoDatabase()
    {
        var x = FileSystem.Current.AppDataDirectory;
        var dbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "todosDb.db");
        var dbLogsPath = Path.Combine(FileSystem.Current.AppDataDirectory, "todosDb-log.db");

        File.Delete(dbPath);
        File.Delete(dbLogsPath);

        _db = new LiteDatabase(dbPath);

        var mapper = BsonMapper.Global;
        mapper.Entity<Todo>().Id(x => x.Id).DbRef(x => x.Collections, Collections_Collection);
        mapper.Entity<TodoCollection>().Id(x => x.Id);

        // Ensure indexes
        Todos.EnsureIndex(x => x.Title);
        Collections.EnsureIndex(x => x.Name);
        Todos.EnsureIndex("CollectionIds", "$.CollectionIds[*]");
    }

    public ILiteCollection<Todo> Todos => _db.GetCollection<Todo>(Todos_Collection);
    public ILiteCollection<TodoCollection> Collections => _db.GetCollection<TodoCollection>(Collections_Collection);

    public void BeginTrans()
    {
        _db.BeginTrans();
    }

    public void Commit()
    {
        _db.Commit();
    }

    public void Dispose()
    {
        _db?.Dispose();
    }
}
