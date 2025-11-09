namespace Bookify.Domain.Shared
{
    public record Currency
    {
        #region Currencies that we could use in our system
        //this is static fields not props
        internal static readonly Currency None = new("");//internal access modifier 3lshan a2dr awslo mn el project da only
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Eur = new("EUR");

        //han3ml bardo 7aga trag3 elcurrencies elly mawgoda 3ndna f el system
        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            Usd,
            Eur
        };
        #endregion
        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ApplicationException("this Currrency is invalid!");
        }
        //e7na hena 3amlna custom construcor 3lshan 5atr e7na 3awzin allowed currency bas (USD & EUR)
        private Currency(string code)
        {
            Code = code;
        }
        public string Code { get; init; } //property not field
    }
}
