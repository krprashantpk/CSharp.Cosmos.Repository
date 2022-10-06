using Azure.Core;
using Cosmos.Repository.Options;
using Cosmos.Repository.Validators;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Providers;

internal class CosmosClientOptionsProvider : ICosmosClientOptionsProvider
{
    private readonly DefaultCosmosClientOptions defaultOptions;
    private readonly IHttpClientFactory clientFactory;

    internal CosmosClientOptionsProvider(CosmosRepositoryOptions options, IHttpClientFactory clientFactory, ICosmosClientOptionsValidator<DefaultCosmosClientOptions> validator)
    {
        this.defaultOptions = options.DefaultCosmosClientOptions;
        validator.Validate();
        this.clientFactory = clientFactory;
    }

    public CosmosClientOptions Get()
    {
        var options = new CosmosClientOptions();

        if(!string.IsNullOrEmpty(defaultOptions.ApplicationName)) options.ApplicationName = defaultOptions.ApplicationName;
        if(defaultOptions.ApplicationPreferredRegions.Any()) options.ApplicationPreferredRegions = defaultOptions.ApplicationPreferredRegions;

        options.ConnectionMode = defaultOptions.Mode;
        options.RequestTimeout = defaultOptions.RequestTimeOut;
        options.HttpClientFactory = () => clientFactory.CreateClient(); //TODO: Move to private method.
        options.EnableContentResponseOnWrite = defaultOptions.OptimizeBandwidth;
        options.ConsistencyLevel = defaultOptions.ConsistencyLevel;
        
        options.SerializerOptions = new CosmosSerializationOptions
        {
            IgnoreNullValues = false,
            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
        };
        return options;

    }

    public (string AccountEndPoint, string? AccountKey, TokenCredential? Token) GetAuthenticatingDetail()
    {
        return (defaultOptions.AccountEndpoint, defaultOptions.AccountKey, defaultOptions.TokenCredential);
    }
}
