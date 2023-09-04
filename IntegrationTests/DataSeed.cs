using Data;
using Data.Entities;

namespace IntegrationTests;

public class DataSeed
{
    private readonly StoriedDbContext _dbContext;

    public DataSeed(StoriedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Dictionary<string, List<Guid>> SeedData()
    {
        var personIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
        var birthEventIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() };
        var locationIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() };

        var person1 = new Person
        {
            Id = personIds[0],
            Versions = new List<PersonVersion>()
            {
                new PersonVersion()
                {
                    Id = Guid.NewGuid(),
                    Gender = new Gender()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Male"
                    },
                    GivenName = "Bob",
                    Surname = "Johnson",
                    VersionDate = DateTime.Now,
                    PersonId = personIds[0],
                    BirthEventId = birthEventIds[0],
                    BirthEvent = new Event()
                    {
                        Id = birthEventIds[0],
                        Location = new Location()
                        {
                            Id = locationIds[0],
                            Name = "Orem"
                        }
                    }
                }
            }
        };
        var person2 = new Person
        {
            Id = personIds[1],
            Versions = new List<PersonVersion>()
            {
                new PersonVersion()
                {
                    Id = Guid.NewGuid(),
                    Gender = new Gender()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Female"
                    },
                    GivenName = "Sara",
                    Surname = "Johnson",
                    VersionDate = DateTime.Now,
                    PersonId = personIds[1],
                    BirthEventId = birthEventIds[1],
                    BirthEvent = new Event()
                    {
                        Id = birthEventIds[1],
                        Location = new Location()
                        {
                            Id = locationIds[1],
                            Name = "Provo"
                        }
                    }
                }
            }
        };
        var person3 = new Person
        {
            Id = personIds[2],
            Versions = new List<PersonVersion>()
            {
                new PersonVersion()
                {
                    Id = Guid.NewGuid(),
                    Gender = new Gender()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Male"
                    },
                    GivenName = "Jim",
                    Surname = "Johnson",
                    VersionDate = DateTime.Now,
                    PersonId = personIds[2]
                }
            }
        };

        _dbContext.People.AddRange(person1, person2, person3);
        _dbContext.SaveChanges();

        var addedIds = new Dictionary<string, List<Guid>>
        {
            ["person"] = personIds,
            ["birthEvent"] = birthEventIds,
            ["location"] = locationIds
        };

        return addedIds;
    }
}