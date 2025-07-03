namespace Car_Rental_System.Infrastructure.Localization;
public class JsonStringLocalizer(IDistributedCache _cache) : IStringLocalizer
{
    private readonly JsonSerializer _serializer = new();
    public LocalizedString this[string name]
    {
        get
        {
            var value = GetString(name);
            return new LocalizedString(name, value);
        }

    }

    public LocalizedString this[string name, params object[] arguments]
    {

        get
        {
            var actualValue = this[name];
            return !actualValue.ResourceNotFound
                ? new LocalizedString(name, string.Format(actualValue.Value, arguments))
                : actualValue;
        }

    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        var path = $"Resources/{Thread.CurrentThread.Name}.json";
        using FileStream stream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        using StreamReader streamReader = new StreamReader(stream);
        using JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
        while (jsonTextReader.Read())
        {
            if (jsonTextReader.TokenType != JsonToken.PropertyName) continue;
            var key = jsonTextReader.Value as string;
            jsonTextReader.Read();
            var value = _serializer.Deserialize<string>(jsonTextReader);
            yield return new LocalizedString(key, value);
        }
    }
    private string GetString(string key)
    {
        var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
        var fullFilePath = Path.GetFullPath(filePath);

        if (File.Exists(fullFilePath))
        {
            var cacheKey = $"locale_{Thread.CurrentThread.CurrentCulture.Name}_{key}";
            var cacheValue = _cache.GetString(cacheKey);

            if (!string.IsNullOrEmpty(cacheValue))
                return cacheValue;

            var result = GetValueFromJson(key, fullFilePath);

            if (!string.IsNullOrEmpty(result))
                _cache.SetString(cacheKey, result);

            return result;
        }
        return "Not Found";
    }

    private string GetValueFromJson(string propertyName, string fullFilePath)
    {
        if (string.IsNullOrEmpty(fullFilePath) || string.IsNullOrEmpty(propertyName)) return string.Empty;
        using FileStream stream = new(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using StreamReader reader = new StreamReader(stream);
        using JsonTextReader jsonTextReader = new JsonTextReader(reader);
        while (jsonTextReader.Read())
        {

            if (jsonTextReader.TokenType == JsonToken.PropertyName && jsonTextReader.Value as string == propertyName)
            {
                jsonTextReader.Read();
                return _serializer.Deserialize<string>(jsonTextReader);

            }


        }
        return string.Empty;
    }
}
