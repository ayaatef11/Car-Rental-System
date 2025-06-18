using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Infrastructure.Localization;
public class JsonStringLocalizerFactory(IDistributedCache _cache) : IStringLocalizerFactory
{

    public IStringLocalizer Create(Type resourceSource)
    {
        return new JsonStringLocalizer(_cache);
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return new JsonStringLocalizer(_cache);
    }
}