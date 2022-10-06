using Cosmos.Repository.Options;
using Microsoft.Azure.Cosmos;

namespace Cosmos.Repository.Builders;

public class ContainerOptionsBuilder
{

    internal readonly ContainerOptions options;
    
    public ContainerOptionsBuilder(Type type)
    {
        if (type is null) throw new ArgumentNullException(nameof(type));
        options = new(type);
    }
    
    public ContainerOptions WithContainerName(string name)
    {
        options.Name = name ?? throw new ArgumentNullException(nameof(name));
        return options;
    }
    
    public ContainerOptions WithPartitionKey(string partitionKey)
    {
        options.PartitionKey = partitionKey ?? throw new ArgumentNullException(nameof(partitionKey));
        return options;
    }
    
    public ContainerOptions WithContainerDefaultTimeToLive(int containerDefaultTimeToLive)
    {
        options.TimeToLive = containerDefaultTimeToLive;
        return options;
    }
   
    public ContainerOptions WithSyncContainerProperties()
    {
        options.SyncContainerProperties = true;
        return options;
    }
    
    public ContainerOptions WithManualThroughput(int throughput = 400)
    {
        if (throughput < 400)
        {
            throw new ArgumentOutOfRangeException(nameof(throughput), "A container must at least must have a throughput level of 400 RU/s");
        }

        options.ThroughputProperties = ThroughputProperties.CreateManualThroughput(throughput);
        return options;
    }
    
    public ContainerOptions WithAutoscaleThroughput(int autoscaleMaxThroughput = 4000)
    {
        if (autoscaleMaxThroughput is < 4000 or > 1000000)
        {
            throw new ArgumentOutOfRangeException(nameof(autoscaleMaxThroughput), "Autoscale throughput should be between 4000 and 1000000 RUs.");
        }

        options.ThroughputProperties = ThroughputProperties.CreateAutoscaleThroughput(autoscaleMaxThroughput);
        return options;
    }
    
    public ContainerOptions WithServerlessThroughput()
    {
        options.ThroughputProperties = null;
        return options;
    }
}

