using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Web.Models;

public class VotingProcessViewModel
{
    public int Id { get; set; }

    [Required]
    public string BirthdayPersonId { get; set; }

    public string BirthdayPersonName { get; set; }

    [Required]
    public string InitiatorId { get; set; }

    public string InitiatorName { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? EndDate { get; set; }

    public List<VoteViewModel> Votes { get; set; }
}
