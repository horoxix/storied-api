namespace Data.Entities;

public class Person
{
    public Guid Id { get; set; }

    public List<PersonVersion> Versions { get; set; }
}
