using Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Configuration;

public static class DataConfig
{
    public static IServiceCollection ConfigureSqlLite(this IServiceCollection services)
    {
        return services.AddDbContext<StoriedDbContext>((serviceProvider, options) =>
        {
            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            options.UseSqlite(appSettings.DbConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(30));
        });
    }
}
