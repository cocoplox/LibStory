using System;
using System.Collections.Generic;

namespace LibStory.Domain.Models;

public partial class Record
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public int PageFrom { get; set; }

    public int PageTo { get; set; }

    public int? PageDiff { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
