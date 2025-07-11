using MauiTodos2.DAL;

namespace MauiTodos2.Services.Todos;
public record DataSynchronizer(MockedRestService MockedRestService, TodoRepository TodoRepository)
{
    public async ValueTask Refresh()
    {
        var newTodos = await MockedRestService.FetchData();

        var oldTodos = TodoRepository.GetAll().ToList();

        var newItems = newTodos.ExceptBy(oldTodos.Select(x => x.Id), x => x.Id).ToList();
        var removedItems = oldTodos.ExceptBy(newTodos.Select(x => x.Id), x => x.Id).ToList();
        var changedItems = newTodos.IntersectBy(oldTodos.Select(x => x.Id), x => x.Id)
            .Where(newItem =>
            {
                var oldItem = oldTodos.FirstOrDefault(x => x.Id == newItem.Id);
                return oldItem != newItem;
            }).ToList();

        foreach (var item in newItems)
        {
            TodoRepository.Insert(item);
        }
        foreach (var item in removedItems)
        {
            TodoRepository.Delete(item);
        }
        foreach (var item in changedItems)
        {
            TodoRepository.Update(item);
        }
    }
}
