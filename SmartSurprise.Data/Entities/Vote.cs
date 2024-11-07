using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSurprise.Data.Entities;

public class Vote
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VotingProcessId { get; set; }

    [ForeignKey(nameof(VotingProcessId))]
    public VotingProcess VotingProcess { get; set; } = default!;

    [Required]
    public string VoterId { get; set; } = default!;

    [ForeignKey(nameof(VoterId))]
    public ApplicationUser Voter { get; set; }= default!;

    [Required]
    public int GiftId { get; set; }

    [ForeignKey(nameof(GiftId))]
    public Gift Gift { get; set; } = default!;
}
