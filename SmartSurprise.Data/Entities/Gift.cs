using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Data.Entities;

public class Gift
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = default!;

    [StringLength(500)]
    public string? Description { get; set; }
}
