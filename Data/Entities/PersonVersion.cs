namespace Data.Entities;

public class PersonVersion
{
    public Guid Id { get; set; }
    public DateTime VersionDate { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public Guid GenderId { get; set; }
    public Guid? BirthEventId { get; set; }
    public Guid? DeathEventId { get; set; }
    public Guid PersonId { get; set; }

    public Person Person { get; set; }
    public Gender Gender { get; set; }
    public Event? BirthEvent { get; set; }
    public Event? DeathEvent { get; set; }
}
