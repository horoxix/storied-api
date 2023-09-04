namespace Data.Filters;

public class GetAllPeopleQueryFilters
{
    public DateTime? StartBirthDate { get; set; }
    public DateTime? EndBirthDate { get; set; }
    public DateTime? StartDeathDate { get; set; }
    public DateTime? EndDeathDate { get; set; }
    public Guid? BirthLocationId { get; set; }
    public Guid? DeathLocationId { get; set; }
}
