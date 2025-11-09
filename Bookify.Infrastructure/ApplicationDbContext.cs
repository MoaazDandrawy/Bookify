using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        //IUnitOfWork goaha SaveChangesAsync w el mafrood yt3mlha Implement bas hia mawgoda already goa el DBContext 3lshan keda msh mdy error 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // da 3lshan el entities configuration yt3mlha apply
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }


        /*
         دي دالة مسؤولة عن تجميع كل الأحداث (Domain Events) من كل الكيانات (Entities) الموجودة في الـ DbContext
وبعدين تنشرها (Publish) باستخدام _publisher.
         */
        public async Task PublishDomainEventsAsync()
        {
            // el entry di kol el entities elly 3andy bamshy 3la kol entity 3andy w bad5ol 3la kol entity bagib el domain events elly fiha
            var domainEvents = ChangeTracker.Entries<Entity>().Select(entry => entry.Entity).SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();// bn3ml clear 3lshan momkn another DBContext tania 3amlt publish l domain event tany l nfs el Entity
                return domainEvents;
            }).ToList();
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}
