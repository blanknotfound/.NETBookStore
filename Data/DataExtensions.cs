using learning.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace learning.Data
{
    public static class DataExtensions
    {
        public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
        {
            using var scope =serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
            await dbContext.Database.MigrateAsync();
        }
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connString = configuration.GetConnectionString("BookStoreContext");
            services.AddSqlServer<BookStoreContext>(connString)
                    .AddScoped<IBookRepository, EntityFrameworkBooksRepository>();

            return services;
        }
    }
}
