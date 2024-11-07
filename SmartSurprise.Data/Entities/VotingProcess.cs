using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSurprise.Data.Entities;

public class VotingProcess
{
    [Key]
    public int Id { get; set; }


    [Required]
    public string InitiatorId { get; set; } = default!;

    [ForeignKey(nameof(InitiatorId))]
    public ApplicationUser Initiator { get; set; } = default!;

    [Required]
    public string BirthdayPersonId { get; set; } = default!;

    [ForeignKey(nameof(BirthdayPersonId))]
    public ApplicationUser BirthdayPerson { get; set; } = default!;

    [Required]
    public DateTime BirthdayDate { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Vote> Votes { get; set; } = [];
}
