namespace API.Configuration;

public static class AppConfig
{
    public static IServiceCollection LoadConfigs(this IServiceCollection services)
    {
        return services.AddConfigOption<AppSettings>();
    }

    private static IServiceCollection AddConfigOption<TConfig>(this IServiceCollection services,
        Action<TConfig,
        IConfiguration> additionalConfig = null)
        where TConfig : class, new()
    {
        return services
            .AddOptions<TConfig>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.Bind(settings);
                additionalConfig?.Invoke(settings, configuration);
            })
            .ValidateDataAnnotations()
            .Services;
    }
}
