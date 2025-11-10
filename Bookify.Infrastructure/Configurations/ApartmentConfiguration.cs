using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("apartments");
            builder.HasKey(apartment => apartment.Id);
            builder.OwnsOne(apartment => apartment.Address);//di hat3ml mapping l kol el columns elly f address goa el apartment entity w lw hia ICollection<Address> ha5liha OwnsMany badl OwnsOne w sa3tha hatkon f seperate table

            builder.Property(apartment => apartment.Name).HasMaxLength(200)
                .HasConversion(name => name.Value/*when write to DB*/, value => new Name(value)/*when read from DB*/);//bn3ml keda 3lshan 5atr da ValueObject w msh hai3rf y3mlha mapping f el DB

            builder.Property(apartment => apartment.Description).HasMaxLength(2000)
                .HasConversion(description => description.Value, value => new Description(value));

            builder.OwnsOne(apartment => apartment.Price, priceBuilder =>
            {
                //hwa hena bi2ol en bardo haikon 3andy 2 props w homa currency w amount w el amount di decimal 3ady bas el currency value object f bi2olha ta7t ezay t read & write
                priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(apartment => apartment.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            // da row version ba2ol fiha eny lazm w ana ba7gz apartment mo3ina lazm akarn ben el data elly ana shaifha w gatly w ben el data elly f el DB f3ln 3lshan lw 7ad 7agz 2ably w sa3tha bikarn 3an tari2 LastBookedOnUtc
            builder.Property<uint>("Version").IsRowVersion();//shadow property
        }
    }
}
