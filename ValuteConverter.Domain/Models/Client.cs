namespace ValuteConverter.Domain.Models;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
    public string RecomendatorPersonalNumber { get; set; }
    public DateTime CreationDate { get; set; }
}
