using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBokking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Bookings
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly ISender _sender;

        public BookingsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking(Guid bookingId, CancellationToken cancellationToken)
        {
            var query = new GetBookingQuery(bookingId);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]        
        // hoa hena 3amlo object wa7d 3lshan ykoon el mawdoo3 monazm aktar w da ashal l el swagger kaman
        public async Task<IActionResult> ReserveBooking(ReserveBookingRequest request,CancellationToken cancellationToken)
        {
            var command = new ReserveBookingCommand(request.ApartmentId,request.UserId,request.StartDate,request.EndDate);
            var result = await _sender.Send(command, cancellationToken);
            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
        }
    }
}
