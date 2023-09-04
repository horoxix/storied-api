namespace Domain.Models;

public class EventDto
{
    public Guid EventTypeId { get; set; }
    public DateTime? EventDate { get; set; }
    public Guid? LocationId { get; set; }
}
