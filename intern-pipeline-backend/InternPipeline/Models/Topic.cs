using System;
using System.Collections.Generic;

namespace InternPipeline.Models;

public partial class Topic
{
    public int TopicId { get; set; }

    public string TopicName { get; set; } = null!;

    public int? SubjectId { get; set; }

    public virtual Subject? Subject { get; set; }
}
