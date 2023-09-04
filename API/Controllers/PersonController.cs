using AutoMapper;

using Domain.Commands;
using Domain.Handlers;
using Domain.Models;
using Domain.Queries;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace API.Controllers;

[ApiController]
[Route("api/v1/people")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly PersonCommandHandler _commandHandler;
    private readonly PersonQueryHandler _queryHandler;
    private readonly IMapper _mapper;

    public PersonController(
        ILogger<PersonController> logger,
        PersonCommandHandler commandHandler,
        PersonQueryHandler queryHandler,
        IMapper mapper)
    {
        _logger = logger;
        _commandHandler = commandHandler;
        _queryHandler = queryHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a person's information by their unique identifier (ID).
    /// </summary>
    /// <param name="id">The ID of the person to retrieve.</param>
    /// <returns>Returns the person's information if found; otherwise, returns a "Person not found" message.</returns>
    /// <remarks>Returns a "Bad Request" response with an error message if an exception occurs during processing.</remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonById(Guid id)
    {
        LogEndpointEntry(nameof(GetPersonById));

        try
        {
            var query = new GetPersonByIdQuery { Id = id };
            var person = await _queryHandler.Handle(query);

            if (person == null)
            {
                return NotFound($"Person not found by Id={id}");
            }

            return Ok(_mapper.Map<PersonDto>(person));
        }
        catch (Exception ex)
        {
            LogException(nameof(GetPersonById), ex);
            return BadRequest($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves a person's information by their unique identifier (ID).
    /// </summary>
    /// <param name="id">The ID of the person to retrieve.</param>
    /// <returns>Returns the person's information if found; otherwise, returns a "Person not found" message.</returns>
    /// <remarks>Returns a "Bad Request" response with an error message if an exception occurs during processing.</remarks>
    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetPersonHistoryById(Guid id)
    {
        LogEndpointEntry(nameof(GetPersonHistoryById));

        try
        {
            var query = new GetPersonHistoryByIdQuery { Id = id };
            var person = await _queryHandler.Handle(query);

            if (person == null)
            {
                return NotFound($"Person not found by Id={id}");
            }

            return Ok(_mapper.Map<PersonHistoryDto>(person));
        }
        catch (Exception ex)
        {
            LogException(nameof(GetPersonById), ex);
            return BadRequest($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves a list of all people records by specified filters
    /// </summary>
    /// <param name="query">The query for retrieving all people records.</param>
    /// <returns>Returns a list of people records if found; otherwise, returns a "No records found" message.</returns>
    /// <remarks>Returns a "Bad Request" response with an error message if an exception occurs during processing.</remarks>
    [HttpPost]
    [Route("all")]
    public async Task<IActionResult> GetAll([FromBody] GetAllPeopleQuery query)
    {
        LogEndpointEntry(nameof(GetAll));

        try
        {
            var people = await _queryHandler.Handle(query);

            if (people == null || !people.Any())
            {
                string queryJson = JsonConvert.SerializeObject(query);
                return NotFound($"No records found for the supplied filters : {queryJson}");
            }

            return Ok(_mapper.Map<List<PersonDto>>(people));
        }
        catch (Exception ex)
        {
            LogException(nameof(GetAll), ex);
            return BadRequest($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a new person to the system.
    /// </summary>
    /// <param name="command">The command to add a person.</param>
    /// <returns>Returns an "Person added successfully" message upon successful addition.</returns>
    /// <remarks>Returns a "Bad Request" response with an error message if an exception occurs during processing.</remarks>
    [HttpPost]
    public async Task<IActionResult> AddPerson([FromBody] AddPersonCommand command)
    {
        LogEndpointEntry(nameof(AddPerson));

        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                throw new ArgumentException(string.Join(", ", errors));
            }

            var person = await _commandHandler.Handle(command);
            return Ok(_mapper.Map<PersonDto>(person));
        }
        catch (Exception ex)
        {
            LogException(nameof(AddPerson), ex);
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand command)
    {
        LogEndpointEntry(nameof(UpdatePerson));

        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                throw new ArgumentException(string.Join(", ", errors));
            }

            var person = await _commandHandler.Handle(command);
            return Ok(_mapper.Map<PersonDto>(person));
        }
        catch (Exception ex)
        {
            LogException(nameof(AddPerson), ex);
            return BadRequest($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Records a birth event for a person in the system.
    /// If the person doesn't exist, it will create the person.
    /// </summary>
    /// <param name="command">The command to record a birth event.</param>
    /// <returns>Returns a "Birth recorded successfully" message upon successful recording.</returns>
    /// <remarks>Returns a "Bad Request" response with an error message if an exception occurs during processing.</remarks>
    [HttpPost]
    [Route("recordBirth")]
    public async Task<IActionResult> RecordBirth([FromBody] RecordBirthCommand command)
    {
        LogEndpointEntry(nameof(RecordBirth));

        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                throw new ArgumentException(string.Join(", ", errors));
            }

            var person = await _commandHandler.Handle(command);
            return Ok(_mapper.Map<PersonDto>(person));
        }
        catch (Exception ex)
        {
            LogException(nameof(RecordBirth), ex);
            return BadRequest($"Error: {ex.Message}");
        }
    }

    private void LogEndpointEntry(string endpointName)
    {
        _logger.LogInformation("Entering {endpointName} Endpoint.",
            endpointName);
    }

    private void LogException(string endpointName, Exception ex)
    {
        _logger.LogInformation("Caught {ex.Type} : {ex.Message} in {endpointName}.",
            ex.GetType(),
            ex.Message,
            endpointName);
    }
}