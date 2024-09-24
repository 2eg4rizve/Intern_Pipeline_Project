namespace InternPipeline.Entities.RequestEntity
{
    public class BlogRequestEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string? BlogImage { get; set; }
    }
}
