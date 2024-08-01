namespace ValuteConverter.Domain.Models;

public class Currency
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string NameLatin { get; set; }
    public DateTime CreationDate { get; set; }
}
