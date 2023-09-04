namespace Domain.Queries
{
    public class GetAllPeopleQuery
    {
        public DateTime? StartBirthDate { get; set; }
        public DateTime? EndBirthDate { get; set; }
        public DateTime? StartDeathDate { get; set; }
        public DateTime? EndDeathDate { get; set; }
        public Guid? BirthLocationId { get; set; }
        public Guid? DeathLocationId { get; set; }
    }
}
