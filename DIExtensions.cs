using MauiTodos2.DAL;
using MauiTodos2.Services.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTodos2
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            services.AddSingleton<DbSeeder>();
            services.AddSingleton<TodoDatabase>();

            services.AddSingleton<TodoRepository>();
            services.AddSingleton<TodoCollectionRepository>();

            services.AddSingleton<MockedRestService>();
            services.AddSingleton<DataSynchronizer>();

            return services;
        } 
    }
}
