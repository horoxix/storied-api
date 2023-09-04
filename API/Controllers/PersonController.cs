using Domain.Commands;
using Domain.Handlers;
using Domain.Queries;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonCommandHandler _commandHandler;
        private readonly PersonQueryHandler _queryHandler;

        public PersonController(
            ILogger<PersonController> logger,
            PersonCommandHandler commandHandler,
            PersonQueryHandler queryHandler)
        {
            _logger = logger;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
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
            try
            {
                var query = new GetPersonByIdQuery { Id = id };
                var person = await _queryHandler.Handle(query);

                if (person == null)
                {
                    return NotFound("Person not found.");
                }

                return Ok(person);
            }
            catch (Exception ex)
            {
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
            try
            {
                var people = await _queryHandler.Handle(query);

                if (people == null || !people.Any())
                {
                    return NotFound("No records found.");
                }

                return Ok(people);
            }
            catch (Exception ex)
            {
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
                return Ok(person);
            }
            catch (Exception ex)
            {
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
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);

                    throw new ArgumentException(string.Join(", ", errors));
                }

                await _commandHandler.Handle(command);
                return Ok("Birth recorded successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}