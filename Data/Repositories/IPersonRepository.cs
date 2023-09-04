using Data.Entities;
using Data.Filters;

namespace Data.Repositories;

public interface IPersonRepository
{
    Task<PersonVersion?> GetById(Guid personId);
    Task<Person?> GetHistoryById(Guid personId);
    Task<List<PersonVersion?>> GetAll(GetAllPeopleQueryFilters filters);
    Task<PersonVersion> Add(PersonVersion person);
    Task<PersonVersion> Update(PersonVersion personVersion);
    Task<PersonVersion> RecordBirth(PersonVersion person);
}