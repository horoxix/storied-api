using System.ComponentModel.DataAnnotations;

using Domain.Models;
using Domain.Validation;

namespace Domain.Commands
{
    public class AddPersonCommand
    {
        [GivenOrSurnameRequired(ErrorMessage = "At least one of Given Name or Surname is required.")]
        public string? GivenName { get; set; }

        [GivenOrSurnameRequired(ErrorMessage = "At least one of Given Name or Surname is required.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Guid GenderId { get; set; }
        public EventDto? BirthEvent { get; set; }
        public EventDto? DeathEvent { get; set; }
    }
}
