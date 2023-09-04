using Data.Entities;

namespace Domain.Models;

public class PersonDto
{
    public Guid Id { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public Gender Gender { get; set; }
    public Event? BirthEvent { get; set; }
    public Event? DeathEvent { get; set; }
    public DateTime VersionDate { get; set; }
}
