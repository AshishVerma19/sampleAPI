using System;
using System.ComponentModel.DataAnnotations;

namespace sampleAPI.Dto;

public class LoginDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [MinLength(5, ErrorMessage = "Minimum length is 5")]
    public string Password { get; set; } = string.Empty;
}
