using Data.Entities;
using Data.Filters;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly StoriedDbContext _context;

    public PersonRepository(StoriedDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a list of all persons asynchronously.
    /// </summary>
    /// <returns>
    /// A list of all persons in the database.
    /// </returns>
    public async Task<List<PersonVersion?>> GetAll(GetAllPeopleQueryFilters filters)
    {
        var originalQuery = DefaultQuery<PersonVersion>();

        if (filters.BirthLocationId.HasValue)
            originalQuery = originalQuery.Where(x => x.BirthEvent.Location.Id == filters.BirthLocationId);
        if (filters.DeathLocationId.HasValue)
            originalQuery = originalQuery.Where(x => x.DeathEvent.Location.Id == filters.DeathLocationId);
        if (filters.StartBirthDate.HasValue)
            originalQuery = originalQuery.Where(x => x.BirthEvent.EventDate >= filters.StartBirthDate);
        if (filters.EndBirthDate.HasValue)
            originalQuery = originalQuery.Where(x => x.BirthEvent.EventDate <= filters.EndBirthDate);
        if (filters.StartDeathDate.HasValue)
            originalQuery = originalQuery.Where(x => x.DeathEvent.EventDate >= filters.StartDeathDate);
        if (filters.EndDeathDate.HasValue)
            originalQuery = originalQuery.Where(x => x.DeathEvent.EventDate <= filters.EndDeathDate);

        return await originalQuery
            .Include(x => x.Gender)
            .Include(x => x.BirthEvent)
            .ThenInclude(x => x.Location)
            .Include(x => x.DeathEvent)
            .ThenInclude(x => x.Location)
            .GroupBy(x => x.PersonId)
            .Select(group => group.OrderByDescending(x => x.VersionDate)
            .FirstOrDefault())
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a person by their unique identifier (ID) asynchronously.
    /// </summary>
    /// <param name="personId">The ID of the person to retrieve.</param>
    /// <returns>
    /// The person with the specified ID, or null if not found.
    /// </returns>
    public async Task<PersonVersion?> GetById(Guid personId)
    {
        return await _context.PersonVersions
            .OrderBy(x => x.VersionDate)
            .Include(x => x.Gender)
            .Include(x => x.BirthEvent)
            .ThenInclude(x => x.Location)
            .Include(x => x.DeathEvent)
            .ThenInclude(x => x.Location)
            .FirstOrDefaultAsync(x => x.PersonId == personId);
    }

    /// <summary>
    /// Retrieves a person by their unique identifier (ID) asynchronously.
    /// </summary>
    /// <param name="personId">The ID of the person to retrieve.</param>
    /// <returns>
    /// The person with the specified ID, or null if not found.
    /// </returns>
    public async Task<Person?> GetHistoryById(Guid personId)
    {
        return await _context.People
            .Include(x => x.Versions)
            .ThenInclude(x => x.Gender)
            .Include(x => x.Versions)
            .ThenInclude(x => x.BirthEvent)
            .ThenInclude(x => x.Location)
            .Include(x => x.Versions)
            .ThenInclude(x => x.DeathEvent)
            .ThenInclude(x => x.Location)
            .FirstOrDefaultAsync(x => x.Id == personId);
    }

    /// <summary>
    /// Adds a new person to the database asynchronously.
    /// </summary>
    /// <param name="person">The person to add to the database.</param>
    /// <returns>
    /// The added person with any modifications applied by the database (e.g., generated ID).
    /// </returns>
    public async Task<PersonVersion> Add(PersonVersion person)
    {
        person.VersionDate = DateTime.Now;
        await SetGender(person);
        if (person.BirthEvent != null)
            await SetLocation(person.BirthEvent);
        if (person.DeathEvent != null)
            await SetLocation(person.DeathEvent);

        var newPerson = new Person() { Versions = new List<PersonVersion>() { person } };

        _context.People.Add(newPerson);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<PersonVersion> Update(PersonVersion personVersion)
    {
        var existingPerson = await _context.People.FirstOrDefaultAsync(x => x.Id == personVersion.PersonId);

        if (existingPerson != null)
        {
            personVersion.VersionDate = DateTime.Now;
            await SetGender(personVersion);
            if (personVersion.BirthEvent != null)
                await SetLocation(personVersion.BirthEvent);
            if (personVersion.DeathEvent != null)
                await SetLocation(personVersion.DeathEvent);

            _context.PersonVersions.Add(personVersion);
            await _context.SaveChangesAsync();
            return personVersion;
        }
        else throw new ArgumentException($"Person not found for Id {personVersion.PersonId}");
    }

    /// <summary>
    /// Records a birth event for a person in the database asynchronously.
    /// </summary>
    /// <param name="personVersion">The person for whom to record a birth event.</param>
    /// <returns>
    /// The updated person entity after recording the birth event.
    /// </returns>
    public async Task<PersonVersion> RecordBirth(PersonVersion personVersion)
    {
        var existingPerson = await _context.People.FirstOrDefaultAsync(x => x.Id == personVersion.Id);

        if (existingPerson != null)
        {
            var latestPersonVersion = _context.PersonVersions
                .OrderBy(x => x.VersionDate)
                .FirstOrDefault(x => x.PersonId == personVersion.Id);

            await SetLocation(personVersion.BirthEvent);

            var newVersion = new PersonVersion()
            {
                GivenName = latestPersonVersion.GivenName,
                Surname = latestPersonVersion.Surname,
                VersionDate = DateTime.Now,
                PersonId = existingPerson.Id,
                GenderId = latestPersonVersion.GenderId,
                BirthEvent = personVersion.BirthEvent,
                DeathEvent = latestPersonVersion.DeathEvent
            };

            _context.PersonVersions.Add(personVersion);
            await _context.SaveChangesAsync();
            return personVersion;
        }
        else throw new ArgumentException($"Person not found for Id {personVersion.PersonId}");
    }

    /// <summary>
    /// Retrieves a default query for a specified entity type.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    private IQueryable<T> DefaultQuery<T>() where T : class
    {
        return from o in _context.Set<T>() select o;
    }

    /// <summary>
    /// Sets the location for an event asynchronously.
    /// </summary>
    private async Task SetLocation(Event @event)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == @event.Location.Id);
        if (location != null)
        {
            @event.Location = location;
        }
    }

    /// <summary>
    /// Sets the gender for an person asynchronously.
    /// </summary>
    private async Task SetGender(PersonVersion version)
    {
        var gender = await _context.Genders.FirstOrDefaultAsync(x => x.Id == version.GenderId);
        if (gender != null)
        {
            version.Gender = gender;
        }
    }
}