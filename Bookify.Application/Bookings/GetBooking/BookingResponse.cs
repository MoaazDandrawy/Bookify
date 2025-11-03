using Bookify.Domain.Bookings;
using Bookify.Domain.Shared;

namespace Bookify.Application.Bookings.GetBooking
{
    // el class da zai el booking blzabt bas bn5lih b el primative type mn 8er value objects
    // da 3aml akno Dto w fih el props elly hatrg3 mn el DB
    // kol el props hatkoon init setter
    //lazm t7ot el id bardo mtnsash 3lshan da mawgood f el Entity
    public sealed class BookingResponse
    {
        public Guid Id { get; init; }
        public Guid ApartmentId { get; init; }
        public Guid UserId { get; init; }
        public DateOnly DurationStart { get; init; }
        public DateOnly DurationEnd { get; init; }
        public decimal PriceAmount { get; init; }
        public string PriceCurrency { get; init; }
        public decimal CleaningFeeAmount { get; init; }
        public string CleaningFeeCurrency { get; init; }
        public decimal AmenitiesUpChargeAmount { get; init; }
        public string AmenitiesUpChargeCurrency{ get; init; }
        public decimal TotalPriceAmount { get; init; }
        public string TotalPriceCurrency { get; init; }
        public int Status { get; init; }
        public DateTime CreatedOnUtc { get; init; }

        //public DateTime? ConfirmedOnUtc { get; init; }
        //public DateTime? RejectedOnUtc { get; init; }
        //public DateTime? CompletedOnUtc { get; init; }
        //public DateTime? CancelledOnUtc { get; init; }
    }
}
