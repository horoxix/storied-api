namespace Data.Entities;

public class Person
{
    public Guid Id { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public Guid GenderId { get; set; }
    public Guid? BirthEventId { get; set; }
    public Guid? DeathEventId { get; set; }


    public Gender Gender { get; set; }
    public Event? BirthEvent { get; set; }
    public Event? DeathEvent { get; set; }
}
