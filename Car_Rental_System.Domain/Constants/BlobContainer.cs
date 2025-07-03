
using System.Text.Json.Serialization;

namespace Car_Rental_System.Domain.Constants;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlobContainer
{
    Users,
    Authors,
    Books
}