using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.ReserveBokking
{
    public record ReserveBookingCommand(Guid ApartmentId,Guid UserId,DateOnly StartDate,DateOnly EndDate) :ICommand<Guid/*Hwa hena mrag3 Guid 3lshan di 3amlia save f el DB f ana el mohm 3andy en 3amlia el save f el DB tkon success w yrg3ly mnha el Id bta3 el Booking el gedid*/>;
}
