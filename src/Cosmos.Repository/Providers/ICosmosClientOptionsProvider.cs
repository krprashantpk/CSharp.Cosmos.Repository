using Azure.Core;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Providers
{
    internal interface ICosmosClientOptionsProvider 
    {
        CosmosClientOptions Get();
        (string AccountEndPoint, string? AccountKey, TokenCredential? Token) GetAuthenticatingDetail();
    }
}
