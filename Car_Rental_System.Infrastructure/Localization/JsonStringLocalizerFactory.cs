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