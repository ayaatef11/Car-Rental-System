﻿namespace Car_Rental_System.Domain.Entities;
public class Car:BaseEntity
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public bool Availability { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public decimal PricePerDay { get; set; }
}


