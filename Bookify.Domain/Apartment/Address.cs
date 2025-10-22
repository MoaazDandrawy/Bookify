namespace Bookify.Domain.Apartment
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