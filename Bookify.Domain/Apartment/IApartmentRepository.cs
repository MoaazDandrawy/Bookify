namespace Bookify.Domain.Apartment
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
 