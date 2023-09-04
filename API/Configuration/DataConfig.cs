using Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Configuration;

public static class DataConfig
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IWebHostEnvironment environment)
    {
        if (environment.IsEnvironment("Integration"))
        {
            services.AddDbContext<StoriedDbContext>(options =>
            {
                options.UseInMemoryDatabase("test-storied");
            });
        }
        else
        {
            services.AddDbContext<StoriedDbContext>((serviceProvider, options) =>
            {
                var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
                options.UseSqlite(appSettings.DbConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(30));
            });
        }
        return services;
    }
}
