using Cosmos.Repository.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Validators;

internal class DefaultCosmosClientOptionsValidator : ICosmosClientOptionsValidator<DefaultCosmosClientOptions>
{
    private readonly DefaultCosmosClientOptions options;

    internal DefaultCosmosClientOptionsValidator(DefaultCosmosClientOptions options)
    {
        this.options = options ?? throw new ArgumentNullException(nameof(options)); ;
    }
    public void Validate()
    {
        var list = new List<string>();

        if (string.IsNullOrEmpty(options.AccountEndpoint) || !Uri.TryCreate(options.AccountEndpoint, UriKind.Absolute, out Uri _))
        {
            list.Add("Add valid Cosomos AccountEndPoint.");
        }

        if (string.IsNullOrEmpty(options.AccountKey) || options.TokenCredential is null)
        {
            list.Add("Add valid Cosomos Token credential or Primary/Secondary Key.");
        }

        if (list.Any()) throw new ArgumentException(list.Aggregate((x, y) => $"{x}, {y}"));
    }
}
