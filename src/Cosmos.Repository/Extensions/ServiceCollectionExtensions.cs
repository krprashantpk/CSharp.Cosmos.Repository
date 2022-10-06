using CSharp.CosmosRepository.Options;
using CSharp.CosmosRepository.Providers;
using CSharp.CosmosRepository.Validators;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCosmosRepository(
        this IServiceCollection services,
        Action<CosmosRepositoryOptions>? optionBuilder = default)
    {

        services.AddOptions<CosmosRepositoryOptions>()
            .Configure<IConfiguration>(
                (options, configuration) =>
                    configuration.GetSection(nameof(CosmosRepositoryOptions)).Bind(options));


        services.AddSingleton<ICosmosClientOptionsProvider, CosmosClientOptionsProvider>();
        services.AddSingleton<ICosmosClientProvider, CosmosClientProvider>();
        services.AddSingleton<ICosmosContainerProvider, CosmosContainerProvider>();
        services.AddSingleton<ICosmosClientOptionsValidator, CosmosClientOptionsValidator>();

        if (optionBuilder != default)
        {
            services.PostConfigure(optionBuilder);
        }


        return services;
    }

    
}
