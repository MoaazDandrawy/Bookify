namespace Bookify.Domain.Apartment
{
    public record Money (decimal Amount, Currency Currency)
    {
        //operator overloading
        public static Money operator + (Money first, Money second)
        {
            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Currencies have to be equal");
            }
            return new Money(first.Amount + second.Amount, first.Currency);
        }
        //3lshan lw 3awz a3ml money value object with default value 
        public static Money Zero()
        {
            return new (0, Currency.None);
        }
    }
}
