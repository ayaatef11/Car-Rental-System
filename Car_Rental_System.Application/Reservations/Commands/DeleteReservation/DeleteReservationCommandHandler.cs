﻿using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reservations.Commands.DeleteReservation;
internal class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.ReservationId);
        if (reservation == null)
            return false;

        _unitOfWork.Repository<Reservation>().Delete(reservation);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
