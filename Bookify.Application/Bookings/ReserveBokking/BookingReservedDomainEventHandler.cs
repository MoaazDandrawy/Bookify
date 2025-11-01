using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBokking
{
    //e7na 3amlna el handler da 3lshan n2ol eh elly hai7sl b2a b3d ma 2olna en fih event ya gama3a w el booking has been reserved 5alas zai masln nb3t confirmation mail l el guest aw han3ml log l el proccess di w nsaglha f el DB
    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
            if (booking is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(
                user.Email,
                "Booking reserved!",
                "You have 10 minutes to confirm this booking"
            );
        }
    }
}
