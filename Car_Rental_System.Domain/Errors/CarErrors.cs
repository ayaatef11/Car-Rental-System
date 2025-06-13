using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Car_Rental_System.Domain.Errors;
public static class AuthorErrors
{
    public static Error NotFound(string id) => Error.NotFound(
        "Author.NotFound",
        $"The author with id '{id}' was not found.");
}
