using System;
using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Web.Models;

public class UserViewModel
{
    public string Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}
