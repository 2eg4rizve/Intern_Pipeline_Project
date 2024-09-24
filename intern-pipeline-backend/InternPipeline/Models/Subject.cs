using System;
using System.Collections.Generic;

namespace InternPipeline.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int? TaskId { get; set; }

    public virtual Task? Task { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
