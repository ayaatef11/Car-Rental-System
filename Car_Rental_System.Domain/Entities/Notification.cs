﻿
namespace Car_Rental_System.Domain.Entities;
public class Notification
{
    public int Id { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; }
}

