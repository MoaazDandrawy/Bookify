namespace Bookify.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            id = Id;
        }
        public Guid Id { get; init; }
    }
}
