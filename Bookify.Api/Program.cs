using Bookify.Application;
using Bookify.Infrastructure;
using Bookify.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Apply migrations automatically in development environment only
    // w ana ba3ml add-migration lazm a5aly el startup project mn foo2 ykoon el API bta3y (Bookify.Api) w mn ta7t f el package manager console a5lih el infrastructure (Bookify.Infrastructure) w lazm a3ml parameterless constructor l el entities kolha.
    app.ApplyMigrations();

    //app.SeedData();
}

app.UseHttpsRedirection();

//app.UseAuthorization(); //hnb2a n3ml e7na keyCloak

app.UseCustomExceptionHandler();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
