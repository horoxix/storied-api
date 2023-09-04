namespace Data.Entities;

public class Event
{
    public Guid Id { get; set; }
    public Guid EventTypeId { get; set; }
    public DateTime? EventDate { get; set; }
    public Location? Location { get; set; }
}
