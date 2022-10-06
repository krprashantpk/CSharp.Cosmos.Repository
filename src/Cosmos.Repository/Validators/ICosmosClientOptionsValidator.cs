
using Cosmos.Repository.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Validators;

internal interface ICosmosClientOptionsValidator<TOptions> where TOptions : DefaultCosmosClientOptions
{
    void Validate();
}