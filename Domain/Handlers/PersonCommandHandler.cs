using AutoMapper;

using Data.Entities;
using Data.Repositories;

using Domain.Commands;

using Microsoft.Extensions.Logging;

namespace Domain.Handlers;

public class PersonCommandHandler
{
    private readonly IPersonRepository _personRepository;
    private readonly ILogger<PersonCommandHandler> _logger;
    private readonly IMapper _mapper;

    public PersonCommandHandler(
        IPersonRepository personRepository,
        ILogger<PersonCommandHandler> logger,
        IMapper mapper)
    {
        _personRepository = personRepository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles a command to add a new person asynchronously.
    /// </summary>
    /// <param name="command">The command specifying the person to add.</param>
    public async Task<PersonVersion> Handle(AddPersonCommand command)
    {
        LogHandlerEntry(nameof(AddPersonCommand));

        return await _personRepository.Add(_mapper.Map<PersonVersion>(command));
    }

    /// <summary>
    /// Handles a command to update an existing person asynchronously.
    /// </summary>
    /// <param name="command">The command specifying the person to update with properties to update.</param>
    public async Task<PersonVersion> Handle(UpdatePersonCommand command)
    {
        LogHandlerEntry(nameof(UpdatePersonCommand));

        return await _personRepository.Update(_mapper.Map<PersonVersion>(command));
    }

    /// <summary>
    /// Handles a command to record a birth event for a person asynchronously.
    /// </summary>
    /// <param name="command">The command specifying the birth event to record.</param>
    public async Task<PersonVersion> Handle(RecordBirthCommand command)
    {
        LogHandlerEntry(nameof(RecordBirthCommand));

        if (command.BirthEvent != null &&
            command.BirthEvent.LocationId == null &&
            command.BirthEvent.EventDate == null)
        {
            throw new ArgumentException("At least one of BirthLocation or BirthDate is required.");
        }

        return await _personRepository.RecordBirth(_mapper.Map<PersonVersion>(command));
    }

    /// <summary>
    /// Logs the entry of a command handler method.
    /// </summary>
    /// <param name="commandName">The name of the command being handled.</param>
    private void LogHandlerEntry(string commandName)
    {
        _logger.LogInformation("Handling {commandName} in {this}",
            commandName,
            this);
    }
}
