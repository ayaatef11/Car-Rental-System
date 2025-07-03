namespace Car_Rental_System.Domain.Errors;
public static class CustomerErrors
{
    public static Error NotFound(string id) => Error.NotFound(
        "Customer.NotFound",
        $"{id}");
}
