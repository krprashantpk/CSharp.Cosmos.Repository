using Cosmos.Repository.Builders;

namespace Cosmos.Repository.Options;

public class CosmosRepositoryOptions
{
    internal IReadOnlyCollection<ContainerOptions> Options { get; } = new List<ContainerOptions>();

    internal DefaultCosmosClientOptionsBuilder DefaultCosmosClientOptionsBuilder { get; } = new DefaultCosmosClientOptionsBuilder();

    public string DatabaseId { get; set; } = "CSharp.Blogs";
    public bool CreateIfNotExist { get; set; } = true;
    public DefaultCosmosClientOptions DefaultCosmosClientOptions => DefaultCosmosClientOptionsBuilder.Options;
    

    internal ContainerOptions GetContainerConfiguration<TType>() where TType : IItem
    {
        var option = Options.FirstOrDefault(x => x.Type == typeof(TType));
        if (option is null) throw new InvalidOperationException($"No configuration of type {typeof(TType)} has been added.");
        return option;
    }
    internal ContainerOptions GetContainerConfiguration(Type type)
    {
        var option = Options.FirstOrDefault(x => x.Type == type);
        if (option is null) throw new InvalidOperationException($"No configuration of type {type} has been added.");
        return option;
    }
    public void ConfigureContainer<TType>(Action<ContainerOptionsBuilder> optionBuilder) where TType : IItem
    {
        if (optionBuilder is null) throw new ArgumentNullException(nameof(optionBuilder));

        var builder = new ContainerOptionsBuilder(typeof(TType));
        optionBuilder.Invoke(builder);
    }
    public void ConfigureContainer(Type type, Action<ContainerOptionsBuilder> optionBuilder)
    {
        if (optionBuilder is null) throw new ArgumentNullException(nameof(optionBuilder));
        var builder = new ContainerOptionsBuilder(type);
        optionBuilder.Invoke(builder);
    }
    public void ConfigureClient(Action<DefaultCosmosClientOptionsBuilder> clientBuilder)
    {
        if (clientBuilder is null) throw new ArgumentNullException(nameof(clientBuilder));
        clientBuilder.Invoke(DefaultCosmosClientOptionsBuilder);
    }

}
