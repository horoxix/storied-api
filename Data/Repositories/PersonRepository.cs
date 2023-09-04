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
    public async Task<List<Person>> GetAll(GetAllPeopleQueryFilters filters)
    {
        var originalQuery = DefaultQuery<Person>();

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
            .Include(x => x.DeathEvent)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a person by their unique identifier (ID) asynchronously.
    /// </summary>
    /// <param name="personId">The ID of the person to retrieve.</param>
    /// <returns>
    /// The person with the specified ID, or null if not found.
    /// </returns>
    public async Task<Person?> GetById(Guid personId)
    {
        return await _context.People
            .Include(x => x.Gender)
            .Include(x => x.BirthEvent)
            .Include(x => x.DeathEvent)
            .FirstOrDefaultAsync(x => x.Id == personId);
    }

    /// <summary>
    /// Adds a new person to the database asynchronously.
    /// </summary>
    /// <param name="person">The person to add to the database.</param>
    /// <returns>
    /// The added person with any modifications applied by the database (e.g., generated ID).
    /// </returns>
    public async Task<Person> Add(Person person)
    {
        if (person.BirthEvent != null)
        {
            await CreateEvent(person.BirthEvent);
        }
        if (person.DeathEvent != null)
        {
            await CreateEvent(person.DeathEvent);
        }

        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    /// <summary>
    /// Records a birth event for a person in the database asynchronously.
    /// </summary>
    /// <param name="person">The person for whom to record a birth event.</param>
    /// <returns>
    /// The updated person entity after recording the birth event.
    /// </returns>
    public async Task<Person> RecordBirth(Person person)
    {
        var existingPerson = await _context.People.FirstOrDefaultAsync(x => x.Id == person.Id);

        if (existingPerson != null)
        {
            if (existingPerson.BirthEvent == null &&
                person.BirthEvent != null)
            {
                await SetLocation(person.BirthEvent);

                existingPerson.BirthEvent = person.BirthEvent;
            }
            else
            {
                if (EventDateNeedsUpdating(existingPerson, person))
                {
                    existingPerson.BirthEvent.EventDate = person.BirthEvent?.EventDate;
                }
                if (EventLocationNeedsUpdating(existingPerson, person))
                {
                    existingPerson.BirthEvent.Location.Id = person.BirthEvent.Location.Id;
                }
            }

            await _context.SaveChangesAsync();
            return person;
        }
        else throw new ArgumentException($"Person not found for Id {person.Id}");
    }

    /// <summary>
    /// Checks if the birth event date needs updating.
    /// </summary>
    private bool EventDateNeedsUpdating(Person existingPerson, Person person)
    {
        return existingPerson.BirthEvent != null &&
            person.BirthEvent != null &&
            existingPerson.BirthEvent.EventDate != person.BirthEvent.EventDate &&
            person.BirthEvent.EventDate.HasValue;
    }

    /// <summary>
    /// Checks if the birth event location needs updating.
    /// </summary>
    private bool EventLocationNeedsUpdating(Person existingPerson, Person person)
    {
        return existingPerson.BirthEvent != null &&
            person.BirthEvent != null &&
            person.BirthEvent.Location.Id != null &&
            existingPerson.BirthEvent.Location.Id != person.BirthEvent.Location.Id;
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
    /// Creates a new event in the database asynchronously.
    /// </summary>
    private async Task CreateEvent(Event @event)
    {
        var existingEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id == @event.Id);
        if (existingEvent == null)
        {
            await SetLocation(@event);

            _context.Events.Add(@event);
        }
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
}