namespace Bookify.Domain.Abstractions
{
    public record Error(string Code,string Name) // string code da el mafrood ykoon unique
    {
        public static Error None = new Error(string.Empty, string.Empty);

        public static Error NullValue = new Error("Error.NullValue", "Null value was provided");
    }
}
