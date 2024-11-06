using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Data.Entities;

public class Gift
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<Vote> Votes { get; set; }
}

