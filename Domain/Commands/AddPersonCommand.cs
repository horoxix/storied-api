﻿using System.ComponentModel.DataAnnotations;

using Domain.Models;
using Domain.Validation;

namespace Domain.Commands;

public class AddPersonCommand
{
    [AtLeastOnePropertyRequired("GivenName", "Surname")]
    public string? GivenName { get; set; }

    public string? Surname { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public Guid GenderId { get; set; }
    public EventDto? BirthEvent { get; set; }
    public EventDto? DeathEvent { get; set; }
}
