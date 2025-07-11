using MauiTodos2.DAL;

namespace MauiTodos2.Entities;

public partial record TodoCollection : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Todo> Todos { get; set; } = new List<Todo>();

    public string ImagePath => $"ms-appdata:///local/CollectionsImages/{ImageName}";
    public int TasksCount => Todos.Count;
    public int CompletedTasksCount => Todos.Where(x => x.IsCompleted).Count();
}

