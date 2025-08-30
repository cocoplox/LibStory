using System;
using System.Collections.Generic;

namespace LibStory.Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Record> Record { get; set; } = new List<Record>();
}
