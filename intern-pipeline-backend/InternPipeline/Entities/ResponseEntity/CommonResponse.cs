namespace InternPipeline.Entities.ResponseEntity
{
    public class CommonResponse
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
