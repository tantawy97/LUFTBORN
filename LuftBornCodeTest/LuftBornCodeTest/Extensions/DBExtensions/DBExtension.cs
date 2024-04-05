using Infrastructure.Persistence.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace LuftBornCodeTest.Extensions.DBExtensions
{
    public static class DBExtensions
    {
        public static IServiceCollection AddSQLServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LuftBornContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LuftBornDB"));
            });
            var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LuftBornContext>();
            context.Database.SetConnectionString(configuration.GetConnectionString("LuftBornDB"));
          
                context.Database.Migrate();
            
            return services;
        }
    }
}
