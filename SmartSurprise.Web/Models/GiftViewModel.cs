﻿using System.ComponentModel.DataAnnotations;

namespace SmartSurprise.Web.Models;

public class GiftViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }
}
