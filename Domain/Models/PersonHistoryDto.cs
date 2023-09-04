namespace Domain.Models;

public class PersonHistoryDto
{
    public Guid Id { get; set; }
    public List<PersonDto> Versions { get; set; }
}
