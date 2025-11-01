namespace Bookify.Application.Abstractions.Clock
{
    // hoa 3aml el interface da 3lshan ykkon sahl f el testing badl ma ykoon el mawdoo3 mo3tamd 3la DateTime.Now w di btt8air daimn f enta momkn t3ml class y3ml implement l el interface da w t5ali el value fixed 7asb ma enta 3awz
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
