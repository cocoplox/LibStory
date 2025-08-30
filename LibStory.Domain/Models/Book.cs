using System;
using System.Collections.Generic;

namespace LibStory.Domain.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Sinopsis { get; set; }

    public int? Pages { get; set; }

    public int? Year { get; set; }

    public string? Author { get; set; }

    public string? Publisher { get; set; }

    public double? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Record> Record { get; set; } = new List<Record>();
}
