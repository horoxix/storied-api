using System.Net;
using System.Text;

using API;

using Data;
using Data.Filters;

using Domain.Commands;
using Domain.Models;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using Xunit;

namespace IntegrationTests
{
    public class PersonControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private List<Guid> _personIds;
        private List<Guid> _birthEventIds;
        private List<Guid> _locationIds;

        public PersonControllerIntegrationTests()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.development.json")
                .Build();

            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .UseEnvironment("Integration"));

            _client = _server.CreateClient();

            var seededData = SeedData();

            _personIds = seededData["person"];
            _birthEventIds = seededData["birthEvent"];
            _locationIds = seededData["location"];
        }

        [Fact]
        public async Task GetPersonById_InvalidId_Returns404NotFound()
        {
            var validPersonId = Guid.NewGuid();
            var response = await _client.GetAsync($"/api/v1/people/{validPersonId}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetPersonById_ValidId_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync($"/api/v1/people/{_personIds[0]}");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetPersonHistoryById_InvalidId_Returns404NotFound()
        {
            var validPersonId = Guid.NewGuid();
            var response = await _client.GetAsync($"/api/v1/people/{validPersonId}/history");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetPersonHistoryById_ValidId_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync($"/api/v1/people/{_personIds[1]}/history");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAll_NoResults_Returns404NotFound()
        {
            var filters = new GetAllPeopleQueryFilters()
            {
                BirthLocationId = Guid.NewGuid()
            };

            var json = JsonConvert.SerializeObject(filters);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/people/all", content);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAll_Results_ReturnsSuccessfulResults()
        {
            var filters = new GetAllPeopleQueryFilters()
            {
                BirthLocationId = _locationIds[0]
            };

            var json = JsonConvert.SerializeObject(filters);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/people/all", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Add_ValidInput_ReturnsSuccessfulResults()
        {
            var command = new AddPersonCommand()
            {
                BirthEvent = new EventDto()
                {
                    EventDate = DateTime.Now.AddYears(-33),
                    EventTypeId = Guid.NewGuid(),
                    LocationId = _locationIds[1]
                },
                GenderId = Guid.NewGuid(),
                Surname = "Jones",
                GivenName = "Jimmy"
            };

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/people", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Add_InvalidInput_ReturnsSuccessfulResults()
        {
            var command = new AddPersonCommand()
            {
                BirthEvent = new EventDto()
                {
                    EventDate = DateTime.Now.AddYears(-33),
                    EventTypeId = Guid.NewGuid(),
                    LocationId = _locationIds[1]
                },
                GenderId = Guid.NewGuid()
            };

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/people", content);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task RecordBirth_ValidInput_ReturnsSuccessfulResults()
        {
            var command = new RecordBirthCommand()
            {
                BirthEvent = new EventDto()
                {
                    EventDate = DateTime.Now.AddYears(-33),
                    EventTypeId = Guid.NewGuid(),
                    LocationId = _locationIds[1]
                },
                Id = _personIds[2]
            };

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/people/recordBirth", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task RecordBirth_InvalidInput_ReturnsSuccessfulResults()
        {
            var command = new RecordBirthCommand()
            {
                BirthEvent = new EventDto()
                {
                    EventTypeId = Guid.NewGuid()
                },
                Id = _personIds[2]
            };

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/people/recordBirth", content);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private Dictionary<string, List<Guid>> SeedData()
        {
            using var scope = _server.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var dbContext = serviceProvider.GetRequiredService<StoriedDbContext>();
            var testDataSeeder = new DataSeed(dbContext);
            return testDataSeeder.SeedData();
        }
    }
}
