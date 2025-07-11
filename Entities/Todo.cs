using MauiTodos2.DAL;
using System.Collections.Immutable;

namespace MauiTodos2.Entities;

public partial record Todo : IEntity
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsCompleted { get; init; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? DueDate { get; init; }
    public int Priotiry { get; init; } = 1; //1 to 5
    public List<TodoCollection> Collections { get; init; } = [];
    public string? ImagePath { get; init; }

    public Coordinate? Coordinate { get; init; }

    public IImmutableList<FileInfo>? AttachedFiles { get; init; }


    public ValueTask ToggleTodo()
    {
        return ValueTask.CompletedTask;
    }

    public virtual bool Equals(Todo? other)
    {
        return other is not null &&
               Id == other.Id &&
               Title == other.Title &&
               Description == other.Description &&
               IsCompleted == other.IsCompleted &&
               CreatedAt == other.CreatedAt &&
               DueDate == other.DueDate &&
               ImagePath == other.ImagePath &&
               Collections.SequenceEqual(other.Collections);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Id);
        hash.Add(Title);
        hash.Add(Description);
        hash.Add(IsCompleted);
        hash.Add(CreatedAt);
        hash.Add(DueDate);
        foreach (var item in Collections)
        {
            hash.Add(item);
        }
        return hash.ToHashCode();
    }
}

public record Coordinate(double Latitude, double Longitude); 

public record FileInfo(string FileName);
