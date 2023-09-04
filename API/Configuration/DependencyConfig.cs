using AutoMapper;

using Data.Repositories;

using Domain.Handlers;
using Domain.Models;

namespace API.Configuration;

public static class DependencyConfig
{
    public static IServiceCollection LoadDependencyInjection(this IServiceCollection services)
    {
        InitializeHandlers(services);
        InitializeLogging(services);
        InitializeRepositories(services);
        InitializeAutoMapper(services);

        return services;
    }

    private static void InitializeHandlers(IServiceCollection services)
    {
        services.AddScoped<PersonCommandHandler>();
        services.AddScoped<PersonQueryHandler>();
    }

    private static void InitializeLogging(IServiceCollection services)
    {
        services.AddLogging(options => { });
    }

    static void InitializeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
    }

    static void InitializeAutoMapper(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
