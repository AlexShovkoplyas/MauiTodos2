using MauiTodos2.Helpers;
using MauiTodos2.Pages;
using MauiTodos2.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiTodos2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddPage<AppShell, AppShellViewModel>(null);
            builder.Services.AddPage<TodosListPage, TodosListViewModel>(RouteNames.TodosList);


            return builder.Build();
        }
    }
}
