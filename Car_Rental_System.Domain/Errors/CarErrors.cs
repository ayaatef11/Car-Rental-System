﻿namespace Car_Rental_System.Domain.Errors;
public static class CarErrors
{
    public static Error NotFound(string id) => Error.NotFound(
        "Car.NotFound",
        $"{id}");
}
