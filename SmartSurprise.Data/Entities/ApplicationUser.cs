using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Data.Entities;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = default!;

    [Required]
    public DateTime BirthDate { get; set; }

    public ICollection<VotingProcess> InitiatedVotingProcesses { get; set; } = [];

    public ICollection<VotingProcess> BirthdayVotingProcesses { get; set; } = [];

    public ICollection<Vote> Votes { get; set; } = [];
}