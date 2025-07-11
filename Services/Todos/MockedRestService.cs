using MauiTodos2.DAL;
using MauiTodos2.Entities;

namespace MauiTodos2.Services.Todos;

public record MockedRestService(TodoRepository TodoRepository)
{
    static int Counter = 1;

    public async Task<IEnumerable<Todo>> FetchData()
    {
        await Task.Delay(1000);
        var todos = TodoRepository.GetAll().ToList();
        todos[0] = todos[0] with { Title = todos[0].Title + " @1" };
        todos[1] = todos[1] with { IsCompleted = !todos[1].IsCompleted };
        todos.Remove(todos[2]);
        todos.Add(new Todo { Title = $"New Task {Counter++}" });
        return todos;
    }
}
