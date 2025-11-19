using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using Bookify.Infrastructure.Authentication;
using Bookify.Infrastructure.Clock;
using Bookify.Infrastructure.Data;
using Bookify.Infrastructure.Email;
using Bookify.Infrastructure.Repositories;
using Dapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Infrastructure
{
    public static class DependencyInjection
    {
        //faida el method asln eny adeef kol el services bta3t el Infrastructure layer f el program.cs elly haikon mawgood f el API project
        //di extension method  3lshan ykon 3andy method esmha AddInfrastructure goa el noo3 elly esmo IServiceCollection elly mawgood asln f el C#
        //this di 3lshan tkoon extenstion method 3lshan a2dr a3ml builder.Services.AddInfrastructure
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();//PostgreSql
                //we used snakeCase becuase Postgre Sql prefers it and the default of EF is TitleCase
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());//di registration l el Unit of work ya3ny lma binady IUnitOfWork biroo7 ydih nos5a mn El ApplicationDbContext

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));//el far2 benha w ben AddDbContext en di btwafr el connection string (Dapper) lakn el AddDbContext btimplement el Linq queries w tsave el 7agat f el DB
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            
            //f el appsettings elly f el Api layer bn5azn el Authentication Options w bnst5dmha hna
            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

            services.ConfigureOptions<JwtBearerOptionsSetup>();

            return services;
        }
    }
}
