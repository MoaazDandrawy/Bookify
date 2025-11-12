using Bookify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //el method di m3mola 3lshan el local development purposes bs ma tkonsh feha 3nd el production environment 
        //el method di bt3ml apply ll migrations 3la el database 3nd el startup bta3 el application automatically msh lazm a3ml ana kol mara update database
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();   
        }
    }
}
