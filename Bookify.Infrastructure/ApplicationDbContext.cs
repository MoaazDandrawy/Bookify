using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        //IUnitOfWork goaha SaveChangesAsync w el mafrood yt3mlha Implement bas hia mawgoda already goa el DBContext 3lshan keda msh mdy error 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
