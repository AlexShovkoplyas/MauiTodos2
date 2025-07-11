using LiteDB;
using MauiTodos2.Entities;

namespace MauiTodos2.DAL;

public class DbSeeder
{
    public async Task Seed(TodoDatabase db)
    {
        await SeedCollections(db);
        await SeedTodos(db);
    }

    private async Task SeedTodos(TodoDatabase db)
    {
        var collections = db.Collections.FindAll().ToList();

        var todos = Enumerable.Range(1, 100).Select(i => new Todo()
        {
            Collections = collections.Where(c => c.Id % i == 0).ToList(),
            CreatedAt = DateTime.Now - TimeSpan.FromDays(6 - i),
            DueDate = DateTime.Now.AddDays(-i),
            Title = $"Task {i}",
            IsCompleted = i % 3 == 0
        });

        db.Todos.Upsert(todos);
    }

    private async Task SeedCollections(TodoDatabase db)
    {
        var destinationCollectionsImagesFolderPath = Path.Combine(FileSystem.AppDataDirectory, "CollectionsImages");
        if (!Directory.Exists(destinationCollectionsImagesFolderPath))
        {
            Directory.CreateDirectory(destinationCollectionsImagesFolderPath);
        }

        var collections = Enumerable.Range(1, 5).Select(x => new TodoCollection()
        {
            Name = $"Collection {x}",
            CreatedAt = DateTime.Now - TimeSpan.FromDays(6 - x),
            ImageName = $"{x}.jpeg"
        });

        foreach (var collection in collections)
        {
            var destinationFilePath = Path.Combine(destinationCollectionsImagesFolderPath, collection.ImageName!);
            if (File.Exists(destinationFilePath))
            {
                continue;
            }   

            var sourceFileStream = await FileSystem.OpenAppPackageFileAsync($"CollectionsImages/{collection.ImageName}");

            using (var DestinationFileStream = File.Create(destinationFilePath))
            {
                await sourceFileStream.CopyToAsync(DestinationFileStream);
            }
        }

        db.Collections.Upsert(collections);
    }
}
