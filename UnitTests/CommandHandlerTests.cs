namespace UnitTests;

using System.Threading.Tasks;

using AutoMapper;

using Data.Entities;
using Data.Repositories;

using Domain.Commands;
using Domain.Handlers;
using Domain.Models;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using Xunit;

public class PersonCommandHandlerTests
{

    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly Mock<ILogger<PersonCommandHandler>> _mockLogger;
    private readonly IMapper _mapper;

    public PersonCommandHandlerTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _mockLogger = new Mock<ILogger<PersonCommandHandler>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
    }

    [Fact]
    public async Task Handle_AddPersonCommand_Success()
    {
        var command = new AddPersonCommand
        {
            GenderId = new Guid("40e513a1-1fbb-41c8-9c9b-8d6bb6d9531a"),
            Surname = "Johnson",
            GivenName = "Robert"
        };

        var personVersion = new PersonVersion();

        _mockPersonRepository.Setup(x => x.Add(It.IsAny<PersonVersion>()))
            .ReturnsAsync(personVersion);

        var handler = new PersonCommandHandler(
            _mockPersonRepository.Object,
            _mockLogger.Object,
            _mapper);

        var result = await handler.Handle(command);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_UpdatePersonCommand_Success()
    {
        var command = new UpdatePersonCommand
        {
            GenderId = new Guid("40e513a1-1fbb-41c8-9c9b-8d6bb6d9531a"),
            Surname = "Johnson",
            GivenName = "Robert"
        };

        var personVersion = new PersonVersion();
        _mockPersonRepository.Setup(repo => repo.Update(It.IsAny<PersonVersion>()))
            .ReturnsAsync(personVersion);


        var handler = new PersonCommandHandler(
            _mockPersonRepository.Object,
            _mockLogger.Object,
            _mapper);

        var result = await handler.Handle(command);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_RecordBirthCommand_Success()
    {
        var command = new RecordBirthCommand
        {
            Id = Guid.NewGuid(),
            BirthEvent = new()
            {
                EventDate = DateTime.Now,
                EventTypeId = new Guid("9dcf30df-ad5b-4a61-8442-fef9b90f2ffa"),
                LocationId = new Guid("500c6a87-40c7-4041-85ae-c2334b801391")
            }
        };

        var personVersion = new PersonVersion();

        _mockPersonRepository.Setup(repo => repo.RecordBirth(It.IsAny<PersonVersion>()))
            .ReturnsAsync(personVersion);

        var handler = new PersonCommandHandler(
            _mockPersonRepository.Object,
            _mockLogger.Object,
            _mapper);

        var result = await handler.Handle(command);

        result.Should().NotBeNull();
    }
}
