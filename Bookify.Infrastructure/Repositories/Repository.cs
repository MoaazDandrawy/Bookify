using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);//el Set() di aknha btrag3 DbSet<Apartment>
        }
        public void Add(T Entity)
        {
            DbContext.Add(Entity);//hena e7na mst5dmnash Set<T> 3lshan hoa hai2dr y7dd el type mn el Entity
        }
    }
}
