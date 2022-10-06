using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Options;

public class ContainerOptions
{
    public ContainerOptions(Type type)
    {
        if (type is not IItem) throw new ArgumentException("Invalid Type.");
        Type = type;
    }

    public Type Type { get; }
    public string Name { get; internal set; }
    public string PartitionKey { get; internal set; }
    public int TimeToLive { get; internal set; } = -1;
    public bool SyncContainerProperties { get; internal set; }
    public ThroughputProperties? ThroughputProperties { get; internal set; }

}
