using System.ComponentModel.DataAnnotations;

namespace API.Configuration;

public class AppSettings
{
    [Required]
    public string DbConnectionString { get; set; }
}
