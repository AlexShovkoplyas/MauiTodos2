namespace MauiTodos2.Helpers
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddPage<TPage, TViewModel>(
            this IServiceCollection services,
            string? route)
            where TPage : Page
        {
            services
                .AddTransient(typeof(TPage))
                .AddTransient(typeof(TViewModel));

            if (route is not null)
                Routing.RegisterRoute(route, typeof(TPage));

            return services;
        }
    }
}
