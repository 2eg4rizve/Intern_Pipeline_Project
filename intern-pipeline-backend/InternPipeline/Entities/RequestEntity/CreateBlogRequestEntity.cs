namespace InternPipeline.Entities.RequestEntity
{
    public class CreateBlogRequestEntity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string? BlogImage { get; set; }
    }
}
