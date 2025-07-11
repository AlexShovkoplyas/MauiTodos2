using MauiTodos2.DAL;

namespace MauiTodos2
{
    public partial class App : Application
    {
        private readonly AppShell appShell;
        private readonly IServiceProvider serviceProvider;

        public App(AppShell appShell
            //, IServiceProvider serviceProvider
            )
        {
            InitializeComponent();
            this.appShell = appShell;

            //this.serviceProvider = serviceProvider;

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //InitializeDatabase(serviceProvider);
            return new Window(appShell);
        }

        private void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TodoDatabase>();
            var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
            Task.Run(async () => await seeder.Seed(db)).Wait();
        }
    }
}