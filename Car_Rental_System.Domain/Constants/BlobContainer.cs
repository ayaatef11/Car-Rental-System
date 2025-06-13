using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Car_Rental_System.Domain.Constants;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlobContainer
{
    Users,
    Authors,
    Books
}