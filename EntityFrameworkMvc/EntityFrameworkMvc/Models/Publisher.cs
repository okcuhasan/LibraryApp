namespace EntityFrameworkMvc.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }

        public List<AuthorPublisher> ?AuthorPublishers { get; set; }
    }
}
