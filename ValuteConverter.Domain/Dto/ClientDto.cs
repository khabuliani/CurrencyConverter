using System.ComponentModel.DataAnnotations;

namespace ValuteConverter.Domain.Dto;

public class ClientDto
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Length(11,11)]
    [Required]
    public string PersonalNumber { get; set; }
    [Length(11, 11)]
    [Required] 
    public string RecomendatorPersonalNumber { get; set; }
}
