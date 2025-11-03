using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Apartments.SearchApartments
{
    // da query hadilo date range w hatrag3 list mn el apartments el available 3andy
    public sealed record SearchApartmentsQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
}
