using AutoMapper;

using Data.Entities;
using Data.Filters;
using Data.Repositories;

using Domain.Queries;

using Microsoft.Extensions.Logging;

namespace Domain.Handlers;

public class PersonQueryHandler
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<PersonQueryHandler> _logger;

    public PersonQueryHandler(
        IPersonRepository personRepository,
        IMapper mapper,
        ILogger<PersonQueryHandler> logger)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles a query to retrieve a person by their unique identifier (ID) asynchronously.
    /// </summary>
    /// <param name="query">The query specifying the person's ID.</param>
    /// <returns>
    /// The person with the specified ID, or null if not found.
    /// </returns>
    public async Task<Person?> Handle(GetPersonByIdQuery query)
    {
        LogHandlerEntry(nameof(GetPersonByIdQuery));

        return await _personRepository.GetById(query.Id);
    }


    /// <summary>
    /// Handles a query to retrieve a list of all persons asynchronously.
    /// </summary>
    /// <param name="query">The query to retrieve all persons.</param>
    /// <returns>
    /// A list of all persons in the database, or null if none are found.
    /// </returns>
    public async Task<List<Person>?> Handle(GetAllPeopleQuery query)
    {
        LogHandlerEntry(nameof(GetAllPeopleQuery));

        var personFilters = _mapper.Map<GetAllPeopleQueryFilters>(query);

        return await _personRepository.GetAll(personFilters);
    }

    /// <summary>
    /// Logs the entry of a query handler method.
    /// </summary>
    /// <param name="queryName">The name of the query being handled.</param>

    private void LogHandlerEntry(string queryName)
    {
        _logger.LogInformation("Handling {queryName} in {this}",
            queryName,
            this);
    }
}
