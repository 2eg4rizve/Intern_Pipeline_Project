using System;
using System.Collections.Generic;

namespace InternPipeline.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public int? TaskDesc { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual Jd? TaskDescNavigation { get; set; }
}
