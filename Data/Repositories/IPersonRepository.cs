using Data.Entities;
using Data.Filters;

namespace Data.Repositories;

public interface IPersonRepository
{
    Task<Person?> GetById(Guid personId);
    Task<List<Person>> GetAll(GetAllPeopleQueryFilters filters);
    Task<Person> Add(Person person);
    Task<Person> RecordBirth(Person person);
}