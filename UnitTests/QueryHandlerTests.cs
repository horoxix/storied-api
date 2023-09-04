namespace UnitTests;

using System.Threading.Tasks;

using AutoMapper;

using Data.Entities;
using Data.Filters;
using Data.Repositories;

using Domain.Handlers;
using Domain.Models;
using Domain.Queries;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using Xunit;

public class PersonQueryHandlerTests
{

    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly Mock<ILogger<PersonQueryHandler>> _mockLogger;
    private readonly IMapper _mapper;

    public PersonQueryHandlerTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _mockLogger = new Mock<ILogger<PersonQueryHandler>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
    }

    [Fact]
    public async Task Handle_GetPersonByIdQuery_Success()
    {
        var query = new GetPersonByIdQuery
        {
            Id = Guid.NewGuid()
        };

        var personVersion = new PersonVersion();

        _mockPersonRepository
            .Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(personVersion);

        var handler = new PersonQueryHandler(
            _mockPersonRepository.Object,
            _mockLogger.Object,
            _mapper);

        var result = await handler.Handle(query);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_GetAllPeopleQuery_Success()
    {
        var query = new GetAllPeopleQuery
        {
            BirthLocationId = Guid.NewGuid()
        };

        var personVersion = new PersonVersion();

        _mockPersonRepository
            .Setup(x => x.GetAll(It.IsAny<GetAllPeopleQueryFilters>()))
            .ReturnsAsync(new List<PersonVersion>() { personVersion });

        var handler = new PersonQueryHandler(
            _mockPersonRepository.Object,
            _mockLogger.Object,
            _mapper);

        var result = await handler.Handle(query);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_GetPersonHistoryById_Success()
    {
        var query = new GetPersonHistoryByIdQuery
        {
            Id = Guid.NewGuid()
        };

        var person = new Person();

        _mockPersonRepository
            .Setup(x => x.GetHistoryById(It.IsAny<Guid>()))
            .ReturnsAsync(person);

        var handler = new PersonQueryHandler(
            _mockPersonRepository.Object,
            _mockLogger.Object,
            _mapper);

        var result = await handler.Handle(query);

        result.Should().NotBeNull();
    }
}
