using System;
using System.Collections.Generic;

namespace InternPipeline.Models;

public partial class Jd
{
    public int JdId { get; set; }

    public string JdTitle { get; set; } = null!;

    public string? JdText { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
