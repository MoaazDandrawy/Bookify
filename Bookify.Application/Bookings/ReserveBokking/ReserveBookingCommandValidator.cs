using Bookify.Application.Abstractions.Behaviors;
using Bookify.Domain.Users;
using FluentValidation;
using System.Data;

namespace Bookify.Application.Bookings.ReserveBokking
{                                                   //from FLuentValidation Library
    public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            //di el validations elly ana 3awz atb2a 3la el ReserveBookingCommand
            RuleFor(r=>r.UserId).NotEmpty();
            RuleFor(r=>r.ApartmentId).NotEmpty();
            RuleFor(r => r.StartDate).LessThan(x => x.EndDate);


        }
    }
}
