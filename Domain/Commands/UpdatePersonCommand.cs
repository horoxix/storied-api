using System.ComponentModel.DataAnnotations;

using Domain.Models;
using Domain.Validation;

namespace Domain.Commands;

public class UpdatePersonCommand
{
    [Required(ErrorMessage = "ID is required to update")]
    public Guid Id { get; set; }

    [AtLeastOnePropertyRequired("GivenName", "Surname")]
    public string? GivenName { get; set; }

    public string? Surname { get; set; }

    public Guid GenderId { get; set; }
    public EventDto? BirthEvent { get; set; }
    public EventDto? DeathEvent { get; set; }
}
