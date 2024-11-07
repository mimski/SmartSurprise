using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Web.Models;

public class VoteViewModel
{
    //public string VoterName { get; set; }

    //[Required]
    //public int GiftId { get; set; }

    //public string GiftName { get; set; }

    [Required]
    public int VotingProcessId { get; set; }

    [Required]
    public string VoterId { get; set; } 

    [Required]
    public int GiftId { get; set; }
}
