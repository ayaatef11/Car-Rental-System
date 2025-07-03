global using Microsoft.AspNetCore.Mvc;
global using Car_Rental_System.Application.Cars.Commands.AddCar;
global using Car_Rental_System.Application.Cars.Commands.DeleteCar;
global using Car_Rental_System.Application.Cars.Commands.UpdateCar;
global using MediatR;
global using Car_Rental_System.Application.Cars.Queries.GetAllCars;
global using Car_Rental_System.Application.Cars.Queries.GetAvailableCars;
global using Car_Rental_System.Application.Cars.Queries.GetCarById;
global using Car_Rental_System.Application.Common.Responses;
global using Car_Rental_System.Application.DTOS;
global using Car_Rental_System.Application.Reservations.Commands.AddReservation;
global using Car_Rental_System.Application.Reservations.Commands.ComputeRange;
global using Car_Rental_System.Application.Reservations.Commands.SetReservationStatus;
global using Car_Rental_System.Application.Reservations.Commands.UpdateReservation;
global using Car_Rental_System.Application.Reservations.Queries.GetAllReservations;
global using Car_Rental_System.Application.Reservations.Queries.GetRentalCharge;
global using Car_Rental_System.Application.Reservations.Queries.GetReservation;
global using Car_Rental_System.Application.Reservations.Queries.GetReservationCount;
global using Car_Rental_System.Application.Reservations.Queries.GetReservationStatus;
global using Microsoft.AspNetCore.Authorization;
global using SharedKernel;
global using Car_Rental_System.Application.Auth.Commands.ConfirmEmail;
global using Car_Rental_System.Application.Auth.Commands.ForgetPassword;
global using Car_Rental_System.Application.Auth.Commands.LoginUser;
global using Car_Rental_System.Application.Auth.Commands.Logout;
global using Car_Rental_System.Application.Auth.Commands.RefreshToken;
global using Car_Rental_System.Application.Auth.Commands.RegisterUser;
global using Car_Rental_System.Application.Auth.Commands.ResetEmailConfirmation;
global using Car_Rental_System.Application.Auth.Commands.ResetPassword;
global using Car_Rental_System.API.Common;
global using Car_Rental_System.Application.Auth.Queries.GetCurrentUser;
global using Car_Rental_System.Domain.Entities;
global using System.Linq.Dynamic.Core.Tokenizer;
global using System.Security.Claims;
global using Car_Rental_System.Application.Customers.Commands.AddCustomer;
global using Car_Rental_System.Application.Customers.Commands.DeleteCustomer;
global using Car_Rental_System.Application.Customers.Commands.UpdateCustomer;
global using Car_Rental_System.Application.Customers.Queries.GetAllCustomers;
global using Car_Rental_System.Application.Customers.Queries.GetCustomer;
global using Car_Rental_System.Application.Customers.Queries.ViewCustomerRentalHistory;
global using Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;
global using Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;

global using Car_Rental_System.Application.Reservations.Commands.DeleteReservation;




