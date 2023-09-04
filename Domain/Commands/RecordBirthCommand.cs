using System.ComponentModel.DataAnnotations;

using Domain.Models;

namespace Domain.Commands;

public class RecordBirthCommand
{
    [Required(ErrorMessage = "ID is required to record birth")]
    public Guid Id { get; set; }

    public EventDto BirthEvent { get; set; }
}
