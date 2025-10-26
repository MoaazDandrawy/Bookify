namespace Bookify.Domain.Apartments
{
    //da keda el default constructor
    public record Address
    (string Country,
     string State,
     string ZipCode,
     string City,
     string Street
    );
}